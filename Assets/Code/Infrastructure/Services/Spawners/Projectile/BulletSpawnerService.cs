using Code.Core.Interfaces.Spawners;
using Code.Gameplay.Bullets;
using Code.Infrastructure.Factories.ProjectileFactories;
using Code.Infrastructure.Services.ObjectPools;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Services.Spawners.Projectile
{
    public class BulletSpawnerService : IBulletSpawnerService, IInitializable
    {
        private const int PoolSize = 10;

        private readonly IProjectileFactory _factory;
        private ObjectPool<Bullet> _pool;

        public BulletSpawnerService(IProjectileFactory factory)
        {
            _factory = factory;
        }

        public void Initialize()
        {
            _pool = new ObjectPool<Bullet>(() => CreateBullet(), PoolSize);
            _pool.Prewarm();
        }

        public void Spawn(Vector3 position, Vector2 direction)
        {
            Bullet bullet = _pool.Get();
            bullet.gameObject.SetActive(true);
            bullet.gameObject.transform.position = position;
            bullet.gameObject.transform.up = direction;
            bullet.SetDirection(direction);
            bullet.Expired += OnBulletExpired;
        }

        private void OnBulletExpired(Bullet bullet)
        {
            bullet.Expired -= OnBulletExpired;
            bullet.gameObject.SetActive(false);
            _pool.Return(bullet);
        }

        private Bullet CreateBullet()
        {
            Bullet bullet = _factory.CreateBullet().GetComponent<Bullet>();
            bullet.gameObject.SetActive(false);
            return bullet;
        }
    }
}