using System.Collections;
using System.Diagnostics.CodeAnalysis;
using Health;
using UnityEngine;
using UnityEngine.UI;
using static InitializationUtils;

public class MainUIScript : MonoBehaviour
{
    private Slider _enemyHealthSlider;
    private Slider _playerHealthSlider;

    private void Awake()
    {
        _enemyHealthSlider = transform.Find("Canvas").Find("EnemyHealthBar").GetComponent<Slider>();
        _playerHealthSlider = transform.Find("Canvas").Find("PlayerHealthBar").GetComponent<Slider>();

        if (_enemyHealthSlider == null)
        {
            StopAndThrowInitializationError("MainUI could not locate EnemyHealthBar Slider");
        }

        if (_playerHealthSlider == null)
        {
            StopAndThrowInitializationError("MainUI could not locate PlayerHealthBar Slider");
        }

        _enemyHealthSlider.value = 1f;
        _playerHealthSlider.value = 1f;
    }

    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    private void Start()
    {
        IHealthSystem playerHealth = GameObject.FindWithTag("Player")?.GetComponent<IHealthSystem>();
        IHealthSystem enemyHealth = GameObject.FindWithTag("Enemy")?.GetComponent<IHealthSystem>();
        if (playerHealth == null)
        {
            StopAndThrowInitializationError($"MainUI could not locate Player's {nameof(IHealthSystem)} component");
        }

        if (enemyHealth == null)
        {
            StopAndThrowInitializationError($"MainUI could not locate Enemy's {nameof(IHealthSystem)} component");
        }

        playerHealth.OnHealthChange += heath => { _playerHealthSlider.value = heath.HealthPercentage; };
        enemyHealth.OnHealthChange += heath => { _enemyHealthSlider.value = heath.HealthPercentage; };
    }
}
