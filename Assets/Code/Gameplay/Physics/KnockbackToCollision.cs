using System;
using UnityEngine;

namespace Code.Gameplay.Physics
{
    public class KnockbackToCollision : MonoBehaviour
    {
        public event Action Knocked;

        private float _knockbackForce;
        private ICollisionDetection _collisionDetection;
        private PhysicsBody2D _body;

        private void Awake()
        {
            _collisionDetection = GetComponent<ICollisionDetection>();
            _body = GetComponent<PhysicsBody2D>();
        }

        private void OnEnable()
            => _collisionDetection.Collided += OnKnockedBack;

        private void OnDisable()
            => _collisionDetection.Collided -= OnKnockedBack;

        public void Init(float knockbackForce) 
            => _knockbackForce = knockbackForce;

        private void OnKnockedBack(Collider2D collider)
        {
            Vector2 direction = (transform.position - collider.transform.position).normalized;
            _body.AddVelocity(direction * _knockbackForce);
            Knocked?.Invoke();
        }
    }
}