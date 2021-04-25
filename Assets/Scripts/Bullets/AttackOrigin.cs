using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InitializationUtils;

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
        private Transform _playerTransform;

        private void Awake()
        {
            prefabList.ForEach(pair => _prefabs[pair.projectileType] = pair.prefab);
            ValidateProjectilePrefabs();

            _transform = transform;
            if (bulletContainer == null)
            {
                StopAndThrowInitializationError("No BulletContainer was provided");
            }
            _bulletContainer = bulletContainer.transform;
            GameObject player = GameObject.FindWithTag("Player");
            if (player == null)
            {
                StopAndThrowInitializationError("Could not locate Player object in scene");
            }
            _playerTransform = player.transform;

        }

        private void Start()
        {
            BeginAttackPattern(AttackPatternType.Cross);
            BeginAttackPattern(AttackPatternType.WazerWall, 3f);
        }

        private void ValidateProjectilePrefabs()
        {
            foreach (ProjectileType type in (ProjectileType[]) Enum.GetValues(typeof(ProjectileType)))
            {
                if (!_prefabs.ContainsKey(type))
                {
                    string message = $"No prefab specified for projectile type '{type}'";
                    StopAndThrowInitializationError(message);
                }
            }
        }

        private void BeginAttackPattern(AttackPatternType pattern, float timeBeforeStarting = 0f)
        {
            _currentSteps[pattern] = 0;
            StartCoroutine(AttackPatternLoop(pattern, timeBeforeStarting));
        }


        private IEnumerator AttackPatternLoop(AttackPatternType pattern, float timeBeforeStarting)
        {
            yield return new WaitForSeconds(timeBeforeStarting);
            while (true)
            {
                int currentStep = _currentSteps[pattern];
                AttackStep attackStep = AttackPatterns.GetNextAttackStep(pattern, currentStep);
                foreach (ProjectileAttack attack in attackStep.ProjectileAttacks)
                {
                    GameObject prefab = _prefabs[attack.Type];
                    Vector2 trajectory = attack.Trajectory.magnitude == 0f ? GetTrajectoryTowardsPlayer() : attack.Trajectory;
                    GameObject projectile = Instantiate(prefab, _transform.position, LookRotation2D(trajectory), _bulletContainer);
                    ProjectileScript projectileScript = projectile.GetComponent<ProjectileScript>();

                    projectileScript.Initialize();
                }

                _currentSteps[pattern]++;
                yield return new WaitForSeconds(attackStep.StepDelay);
            }
            // ReSharper disable once IteratorNeverReturns
        }

        private Vector2 GetTrajectoryTowardsPlayer()
        {
            return (_playerTransform.position - _transform.position).normalized;
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
