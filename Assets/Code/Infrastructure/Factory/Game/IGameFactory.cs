using Code.StaticData;
using UnityEngine;

namespace Code.Infrastructure.Factory.Game
{
    public interface IGameFactory
    {
        GameObject CreatePlayer();
        GameObject CreateEnemy(EnemyType type);
        GameObject CreateGameArea();
    }
}