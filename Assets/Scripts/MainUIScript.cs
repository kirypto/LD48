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
        }

        IHealthSystem enemyHealth = GameObject.FindWithTag("Enemy")?.GetComponent<IHealthSystem>();
        if (enemyHealth != null)
        {
            enemyHealth.OnDamageTaken += enemyHealthSys => print($"Player took damage, now at {enemyHealthSys.Health}");
        }
    }
}
