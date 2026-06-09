using Code.Core.ConfigLoaders;
using Code.Infrastructure.Services.ConfigLoaders;
using Code.Infrastructure.Services.ConfigLoaders.Area;
using Code.Infrastructure.Services.ConfigLoaders.Enemies;
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
            Player = _loader.Load<PlayerConfig>(ConfigPath.Player);
            Enemies = _loader.Load<EnemiesConfig>(ConfigPath.Enemies);
            Area = _loader.Load<AreaConfig>(ConfigPath.Area);
            EnemySpawn = _loader.Load<EnemySpawnConfig>(ConfigPath.EnemySpawn);
        }
    }
}