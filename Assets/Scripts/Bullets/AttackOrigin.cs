using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullets
{
    public class AttackOrigin : MonoBehaviour
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private GameObject bulletContainer;

        private readonly IDictionary<AttackPatternType, int> _currentSteps = new Dictionary<AttackPatternType, int>();
        private Transform _transform;
        private Transform _bulletContainer;

        private void Awake()
        {
            _transform = transform;
            _bulletContainer = bulletContainer.transform;
        }

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
                foreach (ProjectileAttack attack in attackStep.ProjectileAttacks)
                {
                    GameObject projectile = Instantiate(projectilePrefab, _transform.position, LookRotation2D(attack.Trajectory), _bulletContainer);
                    ProjectileScript projectileScript = projectile.GetComponent<ProjectileScript>();

                    projectileScript.Initialize();
                }

                _currentSteps[pattern]++;
                yield return new WaitForSeconds(attackStep.StepDelay);
            }
        }

        private static Quaternion LookRotation2D(Vector2 vector)
        {
            float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
            return Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
