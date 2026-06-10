using Code.Core.ConfigLoaders;
using Code.Gameplay.Bullets;
using Code.Gameplay.Lasers;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Services.ConfigServices;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Factories.ProjectileFactories
{
    public class ProjectileFactory : IProjectileFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IConfigService _configService;
        private readonly IInstantiator _instantiator;

        public ProjectileFactory(IAssetProvider assetProvider, IConfigService configService, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _configService = configService;
            _instantiator = instantiator;
        }

        public GameObject CreateBullet()
        {
            var bulletPrefab = _assetProvider.Load(AssetPath.PlayerBulletPath);

            BulletConfig bulletConfig = _configService.Player.Bullet;

            GameObject bullet = _instantiator.InstantiatePrefab(bulletPrefab);
            bullet.GetComponent<Bullet>().Init(bulletConfig.Lifetime, bulletConfig.Speed);

            return bullet;
        }

        public GameObject CreateLaser()
        {
            var laserPrefab = _assetProvider.Load(AssetPath.LaserPath);

            LaserConfig laserConfig = _configService.Player.Laser;

            GameObject laser = _instantiator.InstantiatePrefab(laserPrefab);
            laser.GetComponent<Laser>().Init(laserConfig.Lifetime);

            return laser;
        }
    }
}