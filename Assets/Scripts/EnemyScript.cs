using System.Collections;
using System.Collections.Generic;
using Health;
using UnityEngine;

[RequireComponent(typeof(HealthBehaviour))]
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


        StartCoroutine(nameof(LoadNextWave));
    }

    private IEnumerator LoadNextWave()
    {
        _waveCounter++;
        foreach (GameObject projectile in GameObject.FindGameObjectsWithTag("Projectile"))
        {
            Destroy(projectile);
        }

        yield return new WaitForEndOfFrame();
        print("Freezing Time");
        Time.timeScale = 0;


        yield return new WaitForSecondsRealtime(5f);
        print("Resuming time");
        Time.timeScale = 1f;
        StopCoroutine(nameof(LoadNextWave));
    }

}
