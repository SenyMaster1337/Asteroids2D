using Code.StaticData;
using UnityEngine;

namespace Code.Core.Interfaces.Spawners
{
    public interface IEnemySpawnerService
    {
        void Spawn(EnemyType type, Vector3? position = null);
    }
}