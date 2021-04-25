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

        public float Health => _currentHealth;
        public float HealthMax => healthWaves[_currentWave];
        public float HealthPercentage => HealthMax / Health;
        public void DealDamage(float damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0f)
            {
                HandleWaveDeath();
            }
        }

        private void HandleWaveDeath()
        {
            OnDeath?.Invoke();
            _currentWave += 1;

            if (_currentWave < healthWaves.Count)
            {
                _currentHealth = healthWaves[_currentWave];
            }
        }

        public event IHealthSystem.OnDeathEvent OnDeath;
    }
}
