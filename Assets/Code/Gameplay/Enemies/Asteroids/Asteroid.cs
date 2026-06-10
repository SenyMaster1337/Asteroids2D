using System;
using Code.Core.Interfaces.Enemy;
using Code.Core.Interfaces.Spawners;
using Code.StaticData;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Code.Gameplay.Enemies.Asteroids
{
    public class Asteroid : MonoBehaviour, IEnemy
    {
        private const float SpreadRadius = 1.25f;

        public GameObject GameObject { get; private set; }
        public EnemyType Type { get; private set; }

        public event Action<IEnemy> Dead;
        public event Action<IEnemy> Expired;

        private int _asteroidDebrisCount;

        private IEnemySpawnerService _enemySpawnerService;
        private AsteroidMover _asteroidMover;

        [Inject]
        private void Construct(IEnemySpawnerService enemySpawnerService)
            => _enemySpawnerService = enemySpawnerService;

        private void Awake()
        {
            GameObject = gameObject;
            _asteroidMover = GetComponent<AsteroidMover>();
        }

        public void SetType(EnemyType type)
            => Type = type;

        public void Init(int asteroidDebrisCountAfterDestroy)
            => _asteroidDebrisCount = asteroidDebrisCountAfterDestroy;

        public void Launch()
            => _asteroidMover.Launch(true);

        public void ReturnToPool()
            => Expired?.Invoke(this);

        public void Die()
        {
            for (int i = 0; i < _asteroidDebrisCount; i++)
                SpawnDebrisAtRandomAngle();

            Dead?.Invoke(this);
        }

        public void ResetVelocity()
            => _asteroidMover.ResetVelocity();

        private void SpawnDebrisAtRandomAngle()
        {
            float angle = Random.Range(0f, Mathf.PI * 2f);
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            _enemySpawnerService.Spawn(EnemyType.AsteroidDebris,
                transform.position + (Vector3)(direction * SpreadRadius));
        }
    }
}