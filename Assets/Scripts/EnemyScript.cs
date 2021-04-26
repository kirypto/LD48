using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bullets;
using Health;
using UnityEngine;
using UnityEngine.SceneManagement;
using static InitializationUtils;

[RequireComponent(typeof(HealthBehaviour))]
[RequireComponent(typeof(AttackOrigin))]
public class EnemyScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObjectsToDisableOnEachWaveEnd;
    [SerializeField] private AudioClip waveDeathClip;
    [SerializeField] private List<AttackPatternForWave> attackPatternsByWave;

    private AttackOrigin _attackOrigin;
    private int _waveCounter;

    private void Awake()
    {
        if (attackPatternsByWave.Select(inner => inner.attackPatterns.Count).Aggregate((a, b) => a + b) == 0)
        {
            StopAndThrowInitializationError("Field attackPatternsByWave was not initialized");
        }
        GetComponent<IHealthSystem>().OnWaveDeath += HandleEnemyWaveDeath;
        _attackOrigin = GetComponent<AttackOrigin>();
    }

    private void Start()
    {
        ScheduleCurrentWaveAttackPatterns();
    }

    private void ScheduleCurrentWaveAttackPatterns()
    {
        if (_waveCounter >= attackPatternsByWave.Count)
        {
            return;
        }

        attackPatternsByWave[_waveCounter].attackPatterns.ForEach(attackPatternWithDelay =>
        {
            _attackOrigin.BeginAttackPattern(attackPatternWithDelay.attackPattern, attackPatternWithDelay.delayInSeconds);
        });
    }

    private void HandleEnemyWaveDeath(IHealthSystem enemyHealth)
    {
        if (_waveCounter < gameObjectsToDisableOnEachWaveEnd.Count)
        {
            gameObjectsToDisableOnEachWaveEnd[_waveCounter].SetActive(false);
        }


        StartCoroutine(enemyHealth.IsPermaDead ? nameof(SlowAndWin) : nameof(LoadNextWave));
    }


    private IEnumerator SlowAndWin()
    {
        Time.timeScale = 0.75f;
        yield return new WaitForSecondsRealtime(0.15f);
        Time.timeScale = 0.5f;
        yield return new WaitForSecondsRealtime(0.15f);
        Time.timeScale = 0.5f;
        yield return new WaitForSecondsRealtime(0.15f);
        Time.timeScale = 0.35f;
        yield return new WaitForSecondsRealtime(0.25f);
        Time.timeScale = 0.2f;
        yield return new WaitForSecondsRealtime(0.25f);
        Time.timeScale = 0.1f;
        yield return new WaitForSecondsRealtime(0.35f);
        Time.timeScale = 0f;
        for (float alpha = 0; alpha <= 1; alpha += 0.02f)
        {
            yield return new WaitForSecondsRealtime(0.05f);
            MainUIScript.SetBlackoutAlpha(alpha);
        }
        StopCoroutine(nameof(SlowAndWin));
        SceneManager.LoadScene("WinScreen");
    }

    private IEnumerator LoadNextWave()
    {
        AudioClipPlayer.PlayAudioAtLocation(waveDeathClip, transform.position);
        _waveCounter++;
        foreach (GameObject projectile in GameObject.FindGameObjectsWithTag("Projectile"))
        {
            Destroy(projectile);
        }

        yield return new WaitForEndOfFrame();
        print("Freezing Time");
        Time.timeScale = 0;


        yield return new WaitForSecondsRealtime(1.5f);
        print("Resuming time");
        Time.timeScale = 1f;
        ScheduleCurrentWaveAttackPatterns();
        StopCoroutine(nameof(LoadNextWave));
    }

}

[Serializable]
public struct AttackPatternForWave
{
    public List<PatternDelayPair> attackPatterns;
}


[Serializable]
public struct PatternDelayPair
{
    public AttackPatternType attackPattern;
    public float delayInSeconds;
}
