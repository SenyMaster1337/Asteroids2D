using System;

namespace Code.Core.Configs.Enemies
{
    public class EnemySpawnConfig : IConfigValidate
    {
        public float AsteroidSpawnIntervalValue;
        public float AlienShipSpawnIntervalValue;

        public void Validate()
        {
            if (AsteroidSpawnIntervalValue < 0)
                throw new Exception("AsteroidSpawnInterval must be >= 0");

            if (AlienShipSpawnIntervalValue < 0)
                throw new Exception("AlienShipSpawnInterval must be >= 0");
        }
    }
}