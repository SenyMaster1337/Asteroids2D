using Code.Core.BaseEnemies;
using Code.Core.Interfaces.Spawners;
using Code.StaticData;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Code.Gameplay.Enemies.Asteroids
{
    public class Asteroid : BaseEnemy
    {
        private const float SpreadRadius = 1.25f;

        private int _asteroidDebrisCount;
        private IEnemySpawnerService _enemySpawnerService;
        private AsteroidMover _asteroidMover;

        [Inject]
        private void Construct(IEnemySpawnerService enemySpawnerService)
            => _enemySpawnerService = enemySpawnerService;

        protected override void OnAwake()
        {
            base.OnAwake();
            _asteroidMover = GetComponent<AsteroidMover>();
        }

        public void Init(int asteroidDebrisCountAfterDestroy)
            => _asteroidDebrisCount = asteroidDebrisCountAfterDestroy;

        public override void Launch()
            => _asteroidMover.Launch(true);

        public override void Die()
        {
            if (TryMarkDead() == false) 
                return;

            for (int i = 0; i < _asteroidDebrisCount; i++)
                SpawnDebrisAtRandomAngle();

            base.Die();
        }

        public override void Reset()
        {
            base.Reset();
            _asteroidMover.ResetVelocity();
        }

        private void SpawnDebrisAtRandomAngle()
        {
            float angle = Random.Range(0f, Mathf.PI * 2f);
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            _enemySpawnerService.Spawn(EnemyType.AsteroidDebris,
                transform.position + (Vector3)(direction * SpreadRadius));
        }
    }
}