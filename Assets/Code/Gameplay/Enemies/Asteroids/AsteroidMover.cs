using Code.Gameplay.Physics;
using UnityEngine;

namespace Code.Gameplay.Enemies.Asteroids
{
    public class AsteroidMover : MonoBehaviour
    {
        private float _speed;
        private float _rotationSpeed;
        private PhysicsBody2D _body2D;

        private void Awake() 
            => _body2D = GetComponent<PhysicsBody2D>();

        private void FixedUpdate()
        {
            transform.position =
                CustomPhysicsEngine.MovePosition(transform.position, _body2D.Velocity.CurrentValue, Time.fixedDeltaTime);
        }

        private void Update()
            => transform.Rotate(0f, 0f, _rotationSpeed * Time.deltaTime);

        public void Init(float speed, float rotationSpeed)
        {
            _speed = speed;
            _rotationSpeed = rotationSpeed;
        }

        public void Launch(bool randomDirection = false)
        {
            _body2D.SetVelocity(randomDirection
                ? Random.insideUnitCircle.normalized * _speed
                : -transform.position.normalized * _speed);
        }

        public void ResetVelocity() 
            => _body2D.SetVelocity(Vector2.zero);
    }
}