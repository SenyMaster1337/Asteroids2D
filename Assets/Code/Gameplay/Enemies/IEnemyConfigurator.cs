using Code.Core.Configs.Enemies;

namespace Code.Gameplay.Enemies
{
    public interface IEnemyConfigurator
    {
        void Configure(EnemiesConfig config);
    }
}