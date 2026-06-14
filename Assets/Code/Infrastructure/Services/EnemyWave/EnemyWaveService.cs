using System.Collections.Generic;
using Code.Core.Interfaces.ConfigServices;
using Code.Core.Interfaces.Spawners;
using Code.Infrastructure.Services.LevelReset;
using Code.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Services.EnemyWave
{
    public class EnemyWaveService : IEnemyWaveService, ITickable, IInitializable, ILevelReset
    {
        private class WaveEntry
        {
            public float Interval { get; private set; }
            public float Timer;

            public WaveEntry(float interval)
            {
                Interval = interval;
                Timer = interval;
            }
        }

        private readonly IEnemySpawnerService _enemySpawner;
        private readonly IConfigService _configService;

        private WaveEntry _waveEntry;
        private Dictionary<EnemyType, WaveEntry> _enemyWaves;
        private bool _isActive;

        public EnemyWaveService(IEnemySpawnerService enemySpawner, IConfigService configService)
        {
            _enemySpawner = enemySpawner;
            _configService = configService;
        }

        public void Initialize()
        {
            var spawnConfig = _configService.EnemySpawn;

            _enemyWaves = new Dictionary<EnemyType, WaveEntry>
            {
                [EnemyType.Asteroid] = new(spawnConfig.AsteroidSpawnIntervalValue),
                [EnemyType.AlienShip] = new(spawnConfig.AlienShipSpawnIntervalValue)
            };
        }

        public void Tick()
        {
            if (_isActive == false)
                return;

            foreach (EnemyType enemyType in _enemyWaves.Keys)
            {
                _waveEntry = _enemyWaves[enemyType];
                _waveEntry.Timer -= Time.deltaTime;

                if (_waveEntry.Timer <= 0f)
                {
                    _enemySpawner.Spawn(enemyType);
                    _waveEntry.Timer = _waveEntry.Interval;
                }
            }
        }

        public void StartWave()
            => _isActive = true;

        public void ResetService() 
            => StopWave();

        private void StopWave() 
            => _isActive = false;
    }
}