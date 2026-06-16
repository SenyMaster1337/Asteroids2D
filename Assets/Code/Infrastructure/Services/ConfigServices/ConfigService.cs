using Code.Core.ConfigLoaders;
using Code.Core.Configs.Area;
using Code.Core.Configs.Enemies;
using Code.Core.Configs.Player;
using Code.Core.Configs.Rewards;
using Code.Core.Interfaces.ConfigServices;
using Code.Infrastructure.Services.ConfigLoaders;
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
        public RewardsConfig Rewards { get; private set; }

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
            Rewards = _loader.Load<RewardsConfig>(ConfigPath.Rewards);
        }

        private void Validate()
        {
            Player.Validate();
            Enemies.Validate();
            Area.Validate();
            EnemySpawn.Validate();
            Rewards.Validate();
        }
    }
}