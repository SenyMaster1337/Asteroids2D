using System;
using UnityEngine;

namespace Code.Gameplay.Physics
{
    public interface ICollisionDetection
    {
        event Action<Collider2D> Collided;
    }
}