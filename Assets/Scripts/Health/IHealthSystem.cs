namespace Health
{
    public interface IHealthSystem
    {
        public float Health { get; }
        public float HealthMax { get; }
        public float HealthPercentage { get; }
        public void DealDamage(float damage);
        public event OnDeathEvent OnDeath;


        public delegate void OnDeathEvent();
    }
}
