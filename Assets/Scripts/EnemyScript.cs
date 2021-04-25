using System.Collections;
using System.Collections.Generic;
using Health;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObjectsToDisableOnEachWaveEnd;

    private int _waveCounter;

    private void Awake()
    {
        gameObject.GetComponent<IHealthSystem>().OnWaveDeath += HandleEnemyWaveDeath;
    }

    private void HandleEnemyWaveDeath(IHealthSystem ignored)
    {
        if (_waveCounter < gameObjectsToDisableOnEachWaveEnd.Count)
        {
            gameObjectsToDisableOnEachWaveEnd[_waveCounter].SetActive(false);
        }

        _waveCounter++;

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
