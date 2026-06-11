using Code.Core.Interfaces.ConfigServices;
using Code.Gameplay.Lasers;
using Code.Gameplay.Physics;
using Code.Gameplay.Players;
using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Factories.PlayerFactories
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;
        private readonly IConfigService _configService;

        public PlayerFactory(IAssetProvider assetProvider, IInstantiator instantiator, IConfigService configService)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
            _configService = configService;
        }

        public GameObject CreatePlayer()
        {
            var prefab = _assetProvider.Load(AssetPath.PlayerPath);
            GameObject player = _instantiator.InstantiatePrefab(prefab);

            var playerConfig = _configService.Player;

            player.GetComponent<Player>().Health
                .Init(playerConfig.Health.MaxHealth);
            player.GetComponent<PhysicsBody2D>()
                .Init(playerConfig.Physics.Mass);
            player.GetComponent<PlayerMover>()
                .Init(playerConfig.Mover.RotationSpeed, playerConfig.Mover.ThrustAcceleration,
                    playerConfig.Mover.MaxSpeed);
            player.GetComponent<PlayerBulletShooter>()
                .Init(playerConfig.Bullet.FireRate);
            player.GetComponent<PlayerLaserShooter>()
                .Init(playerConfig.Laser.MaxCharges, playerConfig.Laser.Cooldown, playerConfig.Laser.FireRate);
            player.GetComponent<PlayerHitHandler>()
                .Init(playerConfig.Invincibility.Duration);
            player.GetComponent<KnockbackToCollision>()
                .Init(playerConfig.Physics.KnockbackForce);

            return player;
        }
    }
}