using System.Collections;
using Health;
using UnityEngine;

public class CameraManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject bossCamera;

    private void Awake()
    {
        bossCamera.SetActive(false);

        IHealthSystem enemyHealthSystem = GameObject.FindWithTag("Enemy")?.GetComponent<IHealthSystem>();
        if (enemyHealthSystem != null)
        {
            enemyHealthSystem.OnWaveDeath += enemyHealth =>
            {
                if (!enemyHealth.IsPermaDead)
                {
                    StartCoroutine(nameof(TempSwitchToBossCam));
                }
            };
        }
    }

    private IEnumerator TempSwitchToBossCam()
    {
        yield return new WaitForEndOfFrame();
        playerCamera.SetActive(false);
        bossCamera.SetActive(true);
        yield return new WaitForSeconds(0.05f); // One 20th of a second after time is resumed
        playerCamera.SetActive(true);
        bossCamera.SetActive(false);

        StopCoroutine(nameof(TempSwitchToBossCam));
    }
}
