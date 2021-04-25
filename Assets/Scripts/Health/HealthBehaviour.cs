using System;
using UnityEngine;

namespace Health
{
    public class HealthBehaviour : MonoBehaviour, IHealthSystem
    {
        public float Health => throw new NotImplementedException();
        public float HealthMax  => throw new NotImplementedException();
        public float HealthPercentage  => throw new NotImplementedException();
        public void DealDamage(float damage)
        {
            throw new NotImplementedException();
        }

        public event IHealthSystem.OnDeathEvent OnDeath;
    }
}
