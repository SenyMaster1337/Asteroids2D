namespace Code.Infrastructure.Services.EnemyWave
{
    public class WaveEntry
    {
        public float Interval { get; private set; }
        public float Timer;

        public WaveEntry(float interval)
        {
            Interval = interval;
            Timer = interval;
        }
    }
}