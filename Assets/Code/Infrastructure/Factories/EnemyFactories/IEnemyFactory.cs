using Code.StaticData;
using UnityEngine;

namespace Code.Infrastructure.Factories.EnemyFactories
{
    public interface IEnemyFactory
    {
        GameObject CreateEnemy(EnemyType type);
    }
}