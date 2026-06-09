using UnityEngine;

namespace Code.Core.Interfaces.Spawners
{
    public interface ILaserSpawnerService
    {
        void Spawn(Vector3 position, Vector2 direction);
    }
}