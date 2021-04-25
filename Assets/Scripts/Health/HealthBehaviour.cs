using System;
using System.Collections.Generic;
using UnityEngine;
using static InitializationUtils;

namespace Health
{
    public class HealthBehaviour : MonoBehaviour, IHealthSystem
    {
        [SerializeField] private List<float> healthWaves = new List<float>();

        private int _currentWave;
        private float _currentHealth;

        private void Awake()
        {
            if (healthWaves.Count == 0)
            {
                StopAndThrowInitializationError($"Failed to initialize {name}, {nameof(healthWaves)} needs at least 1 value.");
            }

            _currentHealth = healthWaves[_currentWave];
        }

        public float Health => ValidateAliveThenReturn(_currentHealth);

        public float HealthMax => ValidateAliveThenReturn(healthWaves[_currentWave]);

        public float HealthPercentage => ValidateAliveThenReturn(Health / HealthMax);

        public bool IsPermaDead => _currentWave >= healthWaves.Count;

        public int FutureWaveCount => ValidateAliveThenReturn(healthWaves.Count - _currentWave);

        public void DealDamage(float damage)
        {
            _currentHealth -= damage;
            OnHealthChange?.Invoke(this);
            if (_currentHealth <= 0f)
            {
                HandleWaveDeath();
            }
        }

        public event IHealthSystem.HealthSystemEvent OnWaveDeath;

        public event IHealthSystem.HealthSystemEvent OnHealthChange;

        private T ValidateAliveThenReturn<T>(T toReturn)
        {
            if (IsPermaDead)
            {
                throw new InvalidOperationException($"Object {name} is perma-dead");
            }

            return toReturn;
        }

        private void HandleWaveDeath()
        {
            _currentWave += 1;
            OnWaveDeath?.Invoke(this);

            if (!IsPermaDead)
            {
                Invoke(nameof(SetHealthForNextWave), 0.01f);
            }
        }

        private void SetHealthForNextWave()
        {
            print("Resetting health for next wave");
            _currentHealth = healthWaves[_currentWave];
            OnHealthChange?.Invoke(this);
        }
    }
}
