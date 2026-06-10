using Code.Core.Interfaces.Spawners;
using Code.Gameplay.Lasers;
using Code.Infrastructure.Factories.ProjectileFactories;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Services.Spawners.Projectile
{
    public class LaserSpawnersService : ILaserSpawnerService, IInitializable
    {
        private readonly IProjectileFactory _factory;

        private Laser _laser;
        private bool _isActive;

        public LaserSpawnersService(IProjectileFactory factory)
        {
            _factory = factory;
        }

        public void Initialize()
        {
            _laser = _factory.CreateLaser().GetComponent<Laser>();
            _laser.Expired += OnLaserExpired;
            _laser.gameObject.SetActive(false);
        }

        public void Spawn(Vector3 position, Vector2 direction)
        {
            if (_isActive)
                return;

            _laser.transform.position = position;
            _laser.transform.up = direction;
            _laser.gameObject.SetActive(true);
            _isActive = true;
        }

        private void OnLaserExpired()
        {
            _laser.gameObject.SetActive(false);
            _isActive = false;
        }
    }
}