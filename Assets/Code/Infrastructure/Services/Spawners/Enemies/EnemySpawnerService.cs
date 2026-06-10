using System;
using System.Collections.Generic;
using Code.Core.Interfaces.Enemy;
using Code.Core.Interfaces.Spawners;
using Code.Gameplay.Area;
using Code.Gameplay.Enemies;
using Code.Infrastructure.Factory.Game;
using Code.Infrastructure.Services.ConfigServices;
using Code.Infrastructure.Services.ObjectPools;
using Code.StaticData;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Code.Infrastructure.Services.Spawners.Enemies
{
    public class EnemySpawnerService : IEnemySpawnerService, IInitializable
    {
        private const int AsteroidPoolSize = 10;
        private const int DebrisPoolSize = 20;
        private const int AlienPoolSize = 3;
        private const float SpawnOffset = 2f;

        public event Action<IEnemy> EnemyDied;

        private readonly IGameFactory _gameFactory;
        private readonly IGameAreaProvider _gameAreaProvider;
        private readonly IConfigService _configService;
        private readonly Dictionary<EnemyType, ObjectPool<IEnemy>> _pools = new();

        private GameArea _area;
        private int _activeCount;

        public EnemySpawnerService(IGameFactory gameFactory, IGameAreaProvider gameAreaProvider,
            IConfigService configService)
        {
            _gameFactory = gameFactory;
            _gameAreaProvider = gameAreaProvider;
            _configService = configService;
        }

        public void Initialize()
        {
            _pools[EnemyType.Asteroid] = new ObjectPool<IEnemy>(()
                => CreateEnemy(EnemyType.Asteroid), AsteroidPoolSize);
            _pools[EnemyType.AsteroidDebris] = new ObjectPool<IEnemy>(()
                => CreateEnemy(EnemyType.AsteroidDebris), DebrisPoolSize);
            _pools[EnemyType.AlienShip] = new ObjectPool<IEnemy>(()
                => CreateEnemy(EnemyType.AlienShip), AlienPoolSize);

            foreach (var pool in _pools.Values)
                pool.Prewarm();
        }

        public void Spawn(EnemyType type, Vector3? position = null)
        {
            if (_activeCount >= _configService.Area.MaxEnemies)
                return;

            IEnemy enemy = _pools[type].Get();
            enemy.GameObject.SetActive(true);
            enemy.GameObject.transform.position = position ?? GetRandomEdgePosition();
            enemy.Launch();
            enemy.Dead += OnEnemyDeath;
            enemy.Expired += OnEnemyReturnToPool;
            _activeCount++;
        }

        private void OnEnemyDeath(IEnemy enemy)
        {
            EnemyDied?.Invoke(enemy);
            OnEnemyReturnToPool(enemy);
        }

        private void OnEnemyReturnToPool(IEnemy enemy)
        {
            enemy.Dead -= OnEnemyDeath;
            enemy.Expired -= OnEnemyReturnToPool;
            enemy.ResetVelocity();
            enemy.GameObject.SetActive(false);
            _pools[enemy.Type].Return(enemy);
            _activeCount--;
        }

        private Vector2 GetRandomEdgePosition()
        {
            _area = _gameAreaProvider.GameArea;
            int edge = Random.Range(0, 4);

            return edge switch
            {
                0 => new Vector2(Random.Range(_area.MinX, _area.MaxX), _area.MaxY + SpawnOffset),
                1 => new Vector2(Random.Range(_area.MinX, _area.MaxX), _area.MinY - SpawnOffset),
                2 => new Vector2(_area.MinX - SpawnOffset, Random.Range(_area.MinY, _area.MaxY)),
                _ => new Vector2(_area.MaxX + SpawnOffset, Random.Range(_area.MinY, _area.MaxY))
            };
        }

        private IEnemy CreateEnemy(EnemyType type)
        {
            IEnemy enemy = _gameFactory.CreateEnemy(type).GetComponent<IEnemy>();
            enemy.GameObject.SetActive(false);
            return enemy;
        }
    }
}