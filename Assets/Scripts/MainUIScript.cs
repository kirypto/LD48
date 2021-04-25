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

        playerHealth.OnDamageTaken += heath => { _playerHealthSlider.value = heath.HealthPercentage; };
        enemyHealth.OnDamageTaken += heath => { _enemyHealthSlider.value = heath.HealthPercentage; };
        enemyHealth.OnWaveDeath += HandleEnemyWaveDeath;
    }

    private void HandleEnemyWaveDeath(IHealthSystem enemyHealthSystem)
    {
        print($"Enemy downed, is perma-dead? {enemyHealthSystem.IsPermaDead}, " +
              $"future wave count: {enemyHealthSystem.FutureWaveCount}");

        print("freezing time");
        Time.timeScale = 0;
        foreach (GameObject projectile in GameObject.FindGameObjectsWithTag("Projectile"))
        {
            Destroy(projectile);
        }

        StartCoroutine(ResetTimeScaleAfterDelay(5f));
    }

    private IEnumerator ResetTimeScaleAfterDelay(float delayInSeconds)
    {
        yield return new WaitForSecondsRealtime(delayInSeconds);
        print("resuming time");
        Time.timeScale = 1f;
    }
}
