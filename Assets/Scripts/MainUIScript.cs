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
            enemyHealth.OnWaveDeath += enemyHealthSys => print($"Enemy downed, is perma-dead? {enemyHealthSys.IsPermaDead}, " +
                                                               $"future wave count: {enemyHealthSys.FutureWaveCount}");
        }
    }
}
