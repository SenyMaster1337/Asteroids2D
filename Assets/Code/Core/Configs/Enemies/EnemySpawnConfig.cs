using System;
using System.Collections.Generic;

namespace Code.Core.Configs.Enemies
{
    public class EnemySpawnConfig : IConfigValidate
    {
        public List<WaveEntryConfig> Waves;

        public void Validate()
        {
            if (Waves == null || Waves.Count == 0)
                throw new Exception("Waves list must not be empty");

            foreach (var wave in Waves)
                wave.Validate();
        }
    }
}