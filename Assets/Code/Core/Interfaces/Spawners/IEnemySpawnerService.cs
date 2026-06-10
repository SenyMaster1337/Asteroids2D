using System;
using Code.Core.BaseEnemies;
using Code.StaticData;
using UnityEngine;

namespace Code.Core.Interfaces.Spawners
{
    public interface IEnemySpawnerService
    {
        event Action<BaseEnemy> EnemyDied;
        void Spawn(EnemyType type, Vector3? position = null);
    }
}