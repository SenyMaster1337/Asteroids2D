using System;
using Code.StaticData;

namespace Code.Core.Configs.Enemies
{
    public class WaveEntryConfig : IConfigValidate
    {
        public EnemyType EnemyType;
        public float SpawnInterval;
        
        public void Validate()
        {
            if (EnemyType == EnemyType.None)
                throw new Exception($"WaveEntry EnemyType cannot be None");

            if (SpawnInterval <= 0)
                throw new Exception($"WaveEntry SpawnInterval for {EnemyType} must be > 0");
        }
    }
}