using Code.Infrastructure.Services.ConfigLoaders.Enemies;

namespace Code.Gameplay.Enemies
{
    public interface IEnemyConfigurator
    {
        void Configure(EnemiesConfig config);
    }
}