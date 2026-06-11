using System;
using System.Collections.Generic;
using Code.Core.BaseEnemies;
using Code.Core.Interfaces.ConfigServices;
using Code.Core.Interfaces.Spawners;
using Code.Gameplay.Area;
using Code.Infrastructure.Factories.EnemyFactories;
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

        public event Action<BaseEnemy> EnemyDied;

        private readonly IEnemyFactory _enemyFactory;
        private readonly IGameAreaProvider _gameAreaProvider;
        private readonly IConfigService _configService;
        private readonly Dictionary<EnemyType, ObjectPool<BaseEnemy>> _pools = new();
        private readonly HashSet<BaseEnemy> _notActiveEnemies = new();

        private GameArea _area;
        private int _activeCount;

        public EnemySpawnerService(IEnemyFactory enemyFactory, IGameAreaProvider gameAreaProvider,
            IConfigService configService)
        {
            _enemyFactory = enemyFactory;
            _gameAreaProvider = gameAreaProvider;
            _configService = configService;
        }

        public void Initialize()
        {
            _pools[EnemyType.Asteroid] = new ObjectPool<BaseEnemy>(()
                => CreateEnemy(EnemyType.Asteroid), AsteroidPoolSize);
            _pools[EnemyType.AsteroidDebris] = new ObjectPool<BaseEnemy>(()
                => CreateEnemy(EnemyType.AsteroidDebris), DebrisPoolSize);
            _pools[EnemyType.AlienShip] = new ObjectPool<BaseEnemy>(()
                => CreateEnemy(EnemyType.AlienShip), AlienPoolSize);

            foreach (var pool in _pools.Values)
                pool.Prewarm();
        }

        public void Spawn(EnemyType type, Vector3? position = null)
        {
            if (_activeCount >= _configService.Area.MaxEnemies)
                return;

            BaseEnemy enemy = _pools[type].Get();
            enemy.gameObject.SetActive(true);
            enemy.gameObject.transform.position = position ?? GetRandomEdgePosition();
            enemy.Launch();
            enemy.Dead += OnEnemyDeath;
            enemy.Expired += OnEnemyExpired;
            _activeCount++;
        }

        private void OnEnemyDeath(BaseEnemy enemy)
        {
            if (IsEnemyInactive(enemy))
                return;

            EnemyDied?.Invoke(enemy);
            ReturnToPool(enemy);
        }

        private void OnEnemyExpired(BaseEnemy enemy)
        {
            if (IsEnemyInactive(enemy))
                return;

            ReturnToPool(enemy);
        }

        private bool IsEnemyInactive(BaseEnemy enemy)
            => _notActiveEnemies.Add(enemy) == false;

        private void ReturnToPool(BaseEnemy enemy)
        {
            _notActiveEnemies.Remove(enemy);
            enemy.Dead -= OnEnemyDeath;
            enemy.Expired -= OnEnemyExpired;
            enemy.ResetVelocity();
            enemy.gameObject.SetActive(false);
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

        private BaseEnemy CreateEnemy(EnemyType type)
        {
            BaseEnemy enemy = _enemyFactory.CreateEnemy(type).GetComponent<BaseEnemy>();
            enemy.gameObject.SetActive(false);
            return enemy;
        }
    }
}