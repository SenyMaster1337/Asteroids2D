using Code.Core.Interfaces.Spawners;
using Code.Infrastructure.Services.ConfigLoaders.Enemies;
using Code.Infrastructure.Services.ConfigServices;
using Code.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Services.EnemyWave
{
    public class EnemyWaveService : IEnemyWaveService, ITickable, IInitializable
    {
        private readonly IEnemySpawnerService _enemySpawner;
        private readonly IConfigService _configService;

        private float _asteroidSpawnInterval;
        private float _alienSpawnInterval;

        private float _asteroidTimer;
        private float _alienTimer;

        private bool _isActive;

        public EnemyWaveService(IEnemySpawnerService enemySpawner, IConfigService configService)
        {
            _enemySpawner = enemySpawner;
            _configService = configService;
        }

        public void Initialize()
        {
            EnemySpawnConfig spawnConfig = _configService.EnemySpawn;

            _asteroidSpawnInterval = spawnConfig.AsteroidSpawnIntervalValue;
            _alienSpawnInterval = spawnConfig.AlienShipSpawnIntervalValue;
        }

        public void Tick()
        {
            if (_isActive == false)
                return;

            _asteroidTimer -= Time.deltaTime;

            if (_asteroidTimer <= 0f)
            {
                _enemySpawner.Spawn(EnemyType.Asteroid);
                _asteroidTimer = _asteroidSpawnInterval;
            }

            _alienTimer -= Time.deltaTime;

            if (_alienTimer <= 0f)
            {
                _enemySpawner.Spawn(EnemyType.AlienShip);
                _alienTimer = _alienSpawnInterval;
            }
        }

        public void Start()
        {
            _asteroidTimer = _asteroidSpawnInterval;
            _alienTimer = _alienSpawnInterval;
            _isActive = true;
        }

        public void Stop()
        {
            _isActive = false;
        }
    }
}