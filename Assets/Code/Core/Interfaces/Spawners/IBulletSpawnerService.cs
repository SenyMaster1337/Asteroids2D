using UnityEngine;

namespace Code.Core.Interfaces.Spawners
{
    public interface IBulletSpawnerService
    {
        void Spawn(Vector3 position, Vector2 direction);
    }
}