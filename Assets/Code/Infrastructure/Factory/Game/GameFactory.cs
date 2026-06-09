using Code.Core.ConfigLoaders;
using Code.Gameplay.Area;
using Code.Gameplay.Enemies;
using Code.Gameplay.Enemies.AlienShips;
using Code.Gameplay.Enemies.Asteroids;
using Code.Gameplay.Lasers;
using Code.Gameplay.Physics;
using Code.Gameplay.Players;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Services.ConfigLoaders;
using Code.Infrastructure.Services.ConfigLoaders.Area;
using Code.Infrastructure.Services.ConfigLoaders.Player;
using Code.Infrastructure.Services.ConfigServices;
using Code.Infrastructure.Services.StaticData;
using Code.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Factory.Game
{
    public class GameFactory : IGameFactory
    {
        private const float EnemyBoundaryAreaOffset = 8f;

        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;
        private readonly IStaticDataService _staticDataService;
        private readonly IConfigService _configService;

        public GameFactory(IAssetProvider assetProvider, IInstantiator instantiator,
            IStaticDataService staticDataService, IConfigService configService)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
            _staticDataService = staticDataService;
            _configService = configService;
        }

        public GameObject CreateGameArea()
        {
            var gameAreaPrefab = _assetProvider.Load(AssetPath.GameAreaPath);
            AreaConfig areaConfig = _configService.Area;

            GameObject area = _instantiator.InstantiatePrefab(gameAreaPrefab);

            area.GetComponent<GameArea>().Init(areaConfig.WorldWidth, areaConfig.WorldHeight);

            area.GetComponentInChildren<EnemyBoundaryArea>().Init(areaConfig.WorldWidth + EnemyBoundaryAreaOffset,
                areaConfig.WorldHeight + EnemyBoundaryAreaOffset);

            return area;
        }

        public GameObject CreatePlayer()
        {
            var playerPrefab = _assetProvider.Load(AssetPath.PlayerPath);

            PlayerHealthConfig healthConfig = _configService.Player.Health;
            PhysicsConfig physicsConfig = _configService.Player.Physics;
            PlayerMoverConfig moverConfig = _configService.Player.Mover;
            BulletConfig bulletConfig = _configService.Player.Bullet;
            LaserConfig laserConfig = _configService.Player.Laser;
            PlayerInvincibilityConfig invincibilityConfig = _configService.Player.Invincibility;

            GameObject player = _instantiator.InstantiatePrefab(playerPrefab);

            if (player.TryGetComponent<PhysicsBody2D>(out var physicsBody))
                physicsBody.Init(_configService.Player.Physics.Mass);

            if (player.TryGetComponent<KnockbackToCollision>(out var knockbackToCollision))
                knockbackToCollision.Init(_configService.Player.Physics.KnockbackForce);

            player.GetComponent<Player>().Health.Init(healthConfig.MaxHealth);
            player.GetComponent<PhysicsBody2D>().Init(physicsConfig.Mass);
            player.GetComponent<PlayerMover>()
                .Init(moverConfig.RotationSpeed, moverConfig.ThrustAcceleration, moverConfig.MaxSpeed);
            player.GetComponent<PlayerBulletShooter>()
                .Init(bulletConfig.FireRate);
            player.GetComponent<PlayerLaserShooter>()
                .Init(laserConfig.MaxCharges, laserConfig.Cooldown, laserConfig.FireRate);
            player.GetComponent<PlayerHitHandler>()
                .Init(invincibilityConfig.Duration);

            return player;
        }

        public GameObject CreateEnemy(EnemyType type)
        {
            var enemyPrefab = _staticDataService.GetEnemyData(type).Prefab;
            GameObject enemy = _instantiator.InstantiatePrefab(enemyPrefab);

            enemy.GetComponent<IEnemy>().SetType(type);

            switch (type)
            {
                case EnemyType.Asteroid:
                    var asteroidConfig = _configService.Enemies.Asteroid;
                    enemy.GetComponent<Asteroid>().Init(asteroidConfig.AsteroidDebrisCount);
                    enemy.GetComponent<AsteroidMover>()
                        .Init(asteroidConfig.Mover.Speed, asteroidConfig.Mover.RotationSpeed);
                    ApplyPhysics(enemy, asteroidConfig.Physics);
                    ApplyKnockback(enemy, asteroidConfig.Physics.KnockbackForce);
                    break;

                case EnemyType.AsteroidDebris:
                    var debrisConfig = _configService.Enemies.AsteroidDebris;
                    enemy.GetComponent<AsteroidMover>()
                        .Init(debrisConfig.Mover.Speed, debrisConfig.Mover.RotationSpeed);
                    ApplyPhysics(enemy, debrisConfig.Physics);
                    ApplyKnockback(enemy, debrisConfig.Physics.KnockbackForce);
                    break;

                case EnemyType.AlienShip:
                    var alienConfig = _configService.Enemies.AlienShip;
                    enemy.GetComponent<AlienShipFollower>()
                        .Init(alienConfig.Follower.Speed, alienConfig.Follower.Agility);
                    ApplyPhysics(enemy, alienConfig.Physics);
                    ApplyKnockback(enemy, alienConfig.Physics.KnockbackForce);
                    break;
            }

            return enemy;
        }

        private void ApplyPhysics(GameObject enemy, PhysicsConfig physics)
        {
            if (enemy.TryGetComponent<PhysicsBody2D>(out var body))
                body.Init(physics.Mass);
        }

        private void ApplyKnockback(GameObject enemy, float knockbackForce)
        {
            if (enemy.TryGetComponent<KnockbackToCollision>(out var knockback))
                knockback.Init(knockbackForce);
        }
    }
}