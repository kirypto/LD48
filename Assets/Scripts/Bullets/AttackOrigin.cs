using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullets
{
    public class AttackOrigin : MonoBehaviour
    {
        [SerializeField] private GameObject projectilePrefab;

        private readonly IDictionary<string, int> _currentSteps = new Dictionary<string, int>();

        private void Start()
        {
            BeginAttackPattern("cross");
        }

        private void BeginAttackPattern(string patternName)
        {
            _currentSteps[patternName] = 0;
            StartCoroutine(AttackPatternLoop(patternName));
        }


        private IEnumerator AttackPatternLoop(string patternName)
        {
            while (true)
            {
                int currentStep = _currentSteps[patternName];
                AttackStep attackStep = AttackPatterns.GetNextAttackStep(patternName, currentStep);
                print($"Performing step of: {patternName}, firing {attackStep.ProjectileAttacks.Count}, " +
                      $"delaying {attackStep.StepDelay} seconds.");

                _currentSteps[patternName]++;
                yield return new WaitForSeconds(attackStep.StepDelay);
            }
        }
    }
}
