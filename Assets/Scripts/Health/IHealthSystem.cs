namespace Health
{
    public interface IHealthSystem
    {
        public float Health { get; }
        public float HealthMax { get; }
        public float HealthPercentage { get; }
        public bool IsPermaDead { get; }
        public int FutureWaveCount { get; }
        public void DealDamage(float damage);
        public event HealthSystemEvent OnWaveDeath;
        public event HealthSystemEvent OnDamageTaken;

        public delegate void HealthSystemEvent(IHealthSystem healthSystem);
    }
}
