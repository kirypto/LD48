using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Bullets
{
    public class AttackOrigin : MonoBehaviour
    {
        [SerializeField] private GameObject bulletContainer;
        [SerializeField] private List<ProjectileTypeToPrefabPair> prefabList;

        private readonly IDictionary<AttackPatternType, int> _currentSteps = new Dictionary<AttackPatternType, int>();
        private readonly IDictionary<ProjectileType, GameObject> _prefabs = new Dictionary<ProjectileType, GameObject>();
        private Transform _transform;
        private Transform _bulletContainer;

        private void Awake()
        {
            prefabList.ForEach(pair => _prefabs[pair.projectileType] = pair.prefab);
            ValidateProjectilePrefabs();

            _transform = transform;
            _bulletContainer = bulletContainer.transform;
        }

        private void ValidateProjectilePrefabs()
        {
            foreach (ProjectileType type in (ProjectileType[]) Enum.GetValues(typeof(ProjectileType)))
            {
                if (!_prefabs.ContainsKey(type))
                {
                    string message = $"No prefab specified for projectile type '{type}'";
#if UNITY_EDITOR
                    Debug.LogError(message);
                    EditorApplication.isPlaying = false;
#else
                    throw new ArgumentException(message);
#endif
                }
            }
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
                    GameObject prefab = _prefabs[attack.Type];
                    GameObject projectile = Instantiate(prefab, _transform.position, LookRotation2D(attack.Trajectory), _bulletContainer);
                    ProjectileScript projectileScript = projectile.GetComponent<ProjectileScript>();

                    projectileScript.Initialize();
                }

                _currentSteps[pattern]++;
                yield return new WaitForSeconds(attackStep.StepDelay);
            }
            // ReSharper disable once IteratorNeverReturns
        }

        private static Quaternion LookRotation2D(Vector2 vector)
        {
            float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
            return Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    [Serializable]
    public struct ProjectileTypeToPrefabPair
    {
        public ProjectileType projectileType;
        public GameObject prefab;
    }
}
