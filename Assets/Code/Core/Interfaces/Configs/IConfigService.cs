using Code.Infrastructure.Services.ConfigLoaders.Area;
using Code.Infrastructure.Services.ConfigLoaders.Enemies;
using Code.Infrastructure.Services.ConfigLoaders.Player;

namespace Code.Infrastructure.Services.ConfigServices
{
    public interface IConfigService
    {
        PlayerConfig Player { get; }
        EnemiesConfig Enemies { get; }
        AreaConfig Area { get; }
        EnemySpawnConfig EnemySpawn { get; }
    }
}