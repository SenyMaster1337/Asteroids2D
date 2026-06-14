using Code.Core.Configs.Area;
using Code.Core.Configs.Enemies;
using Code.Core.Configs.Player;

namespace Code.Core.Interfaces.ConfigServices
{
    public interface IConfigService
    {
        PlayerConfig Player { get; }
        EnemiesConfig Enemies { get; }
        AreaConfig Area { get; }
        EnemySpawnConfig EnemySpawn { get; }
    }
}