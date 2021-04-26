using System.Diagnostics.CodeAnalysis;
using Health;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static InitializationUtils;

public class MainUIScript : MonoBehaviour
{
    #region Static API

    private static MainUIScript _instance;

    public static void SetBlackoutAlpha(float alpha)
    {
        _instance._blackoutImage.color = new Color(0, 0, 0, alpha);
    }

    #endregion

    private Slider _enemyHealthSlider;
    private Slider _playerHealthSlider;
    private Image _blackoutImage;

    private void Awake()
    {
        _instance = this;
        _enemyHealthSlider = transform.Find("Canvas").Find("EnemyHealthBar").GetComponent<Slider>();
        _playerHealthSlider = transform.Find("Canvas").Find("PlayerHealthBar").GetComponent<Slider>();
        _blackoutImage = transform.Find("Canvas").Find("Blackout").GetComponent<Image>();

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
