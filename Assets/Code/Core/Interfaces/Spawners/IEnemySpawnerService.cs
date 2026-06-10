using System;
using Code.Core.Interfaces.Enemy;
using Code.StaticData;
using UnityEngine;

namespace Code.Core.Interfaces.Spawners
{
    public interface IEnemySpawnerService
    {
        event Action<IEnemy> EnemyDied;
        void Spawn(EnemyType type, Vector3? position = null);
    }
}