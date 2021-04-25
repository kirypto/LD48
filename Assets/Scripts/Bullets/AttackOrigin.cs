using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullets
{
    public class AttackOrigin : MonoBehaviour
    {
        [SerializeField] private GameObject projectilePrefab;

        private readonly IDictionary<AttackPatternType, int> _currentSteps = new Dictionary<AttackPatternType, int>();

        private void Start()
        {
            BeginAttackPattern(AttackPatternType.Cross);
        }

        private void BeginAttackPattern(AttackPatternType pattern)
        {
            _currentSteps[pattern] = 0;
            StartCoroutine(AttackPatternLoop(pattern));
        }


        private IEnumerator AttackPatternLoop(AttackPatternType pattern)
        {
            while (true)
            {
                int currentStep = _currentSteps[pattern];
                AttackStep attackStep = AttackPatterns.GetNextAttackStep(pattern, currentStep);
                print($"Performing step of: {pattern}, firing {attackStep.ProjectileAttacks.Count}, " +
                      $"delaying {attackStep.StepDelay} seconds.");

                _currentSteps[pattern]++;
                yield return new WaitForSeconds(attackStep.StepDelay);
            }
        }
    }
}
