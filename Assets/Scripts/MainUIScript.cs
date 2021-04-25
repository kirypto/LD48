using System.Collections;
using Health;
using UnityEngine;

public class MainUIScript : MonoBehaviour
{
    private void Awake()
    {
        IHealthSystem playerHealth = GameObject.FindWithTag("Player")?.GetComponent<IHealthSystem>();
        if (playerHealth != null)
        {
            playerHealth.OnDamageTaken += playerHealthSystem => print($"Player took damage, now at {playerHealthSystem.Health}");
            playerHealth.OnWaveDeath += playerHealthSys => print($"Enemy downed, is perma-dead? {playerHealthSys.IsPermaDead}, " +
                                                                 $"future wave count: {playerHealthSys.FutureWaveCount}");
        }

        IHealthSystem enemyHealth = GameObject.FindWithTag("Enemy")?.GetComponent<IHealthSystem>();
        if (enemyHealth != null)
        {
            enemyHealth.OnDamageTaken += enemyHealthSys => print($"Enemy took damage, now at {enemyHealthSys.Health}");
            enemyHealth.OnWaveDeath += HandleEnemyWaveDeath;
        }
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
