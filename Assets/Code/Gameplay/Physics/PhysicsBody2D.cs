using R3;
using UnityEngine;

namespace Code.Gameplay.Physics
{
    public class PhysicsBody2D : MonoBehaviour
    {
        public ReactiveProperty<Vector2> Velocity { get; set; } = new();
        public float Mass { get; private set; }

        public void Init(float mass) 
            => Mass = mass;
    }
}