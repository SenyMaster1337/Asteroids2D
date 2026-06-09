using Code.StaticData;

namespace Code.Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        EnemyData GetEnemyData(EnemyType enemyType);
    }
}