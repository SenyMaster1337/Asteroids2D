using System;
using Code.Core.ConfigLoaders;
using Code.Core.Configs.Area;
using Code.Core.Configs.Enemies;
using Code.Core.Interfaces.ConfigServices;
using Code.Infrastructure.Services.ConfigLoaders;
using Code.Infrastructure.Services.ConfigLoaders.Player;
using Zenject;

namespace Code.Infrastructure.Services.ConfigServices
{
    public class ConfigService : IInitializable, IConfigService
    {
        private readonly IConfigLoader _loader;

        public PlayerConfig Player { get; private set; }
        public EnemiesConfig Enemies { get; private set; }
        public AreaConfig Area { get; private set; }
        public EnemySpawnConfig EnemySpawn { get; private set; }

        public ConfigService(IConfigLoader loader)
        {
            _loader = loader;
        }

        public void Initialize()
        {
            Load();
            Validate();
        }

        private void Load()
        {
            Player = _loader.Load<PlayerConfig>(ConfigPath.Player);
            Enemies = _loader.Load<EnemiesConfig>(ConfigPath.Enemies);
            Area = _loader.Load<AreaConfig>(ConfigPath.Area);
            EnemySpawn = _loader.Load<EnemySpawnConfig>(ConfigPath.EnemySpawn);
        }

        private void Validate()
        {
            if (Player.Health.MaxHealth <= 0)
                throw new Exception("Player MaxHealth must be greater than 0");
            if (Player.Mover.MaxSpeed <= 0)
                throw new Exception("Player MaxSpeed must be greater than 0");
            if (Player.Mover.ThrustAcceleration <= 0)
                throw new Exception("Player ThrustAcceleration must be greater than 0");
            if (Player.Mover.RotationSpeed <= 0)
                throw new Exception("Player RotationSpeed must be greater than 0");

            if (Player.Laser.MaxCharges <= 0)
                throw new Exception("Laser MaxCharges must be greater than 0");
            if (Player.Laser.Cooldown <= 0)
                throw new Exception("Laser Cooldown must be greater than 0");

            if (Player.Bullet.FireRate <= 0)
                throw new Exception("Bullet FireRate must be greater than 0");
            if (Player.Bullet.Speed < 0)
                throw new Exception("Bullet Speed must not be negative");

            if (Enemies.Asteroid.Mover.Speed < 0)
                throw new Exception("Asteroid Speed must not be negative");
            if (Enemies.AlienShip.Follower.Speed < 0)
                throw new Exception("AlienShip Speed must not be negative");

            if (Area.WorldWidth <= 0)
                throw new Exception("WorldWidth must be greater than 0");
            if (Area.WorldHeight <= 0)
                throw new Exception("WorldHeight must be greater than 0");
            if (Area.MaxEnemies <= 0)
                throw new Exception("MaxEnemies must be greater than 0");

            if (EnemySpawn.AsteroidSpawnIntervalValue < 0)
                throw new Exception("AsteroidSpawnInterval must be greater than 0");
            if (EnemySpawn.AlienShipSpawnIntervalValue < 0)
                throw new Exception("AlienShipSpawnInterval must be greater than 0");
        }
    }
}