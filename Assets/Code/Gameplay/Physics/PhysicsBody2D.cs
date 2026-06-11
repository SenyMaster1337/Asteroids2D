using R3;
using UnityEngine;

namespace Code.Gameplay.Physics
{
    public class PhysicsBody2D : MonoBehaviour
    {
        private readonly ReactiveProperty<Vector2> _velocity = new();

        public ReadOnlyReactiveProperty<Vector2> Velocity => _velocity;

        public float Mass { get; private set; }

        public void Init(float mass)
            => Mass = mass;

        public void SetVelocity(Vector2 velocity)
            => _velocity.Value = velocity;

        public void AddVelocity(Vector2 delta)
            => _velocity.Value += delta;
    }
}