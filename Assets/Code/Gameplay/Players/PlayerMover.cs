using Code.Core.Interfaces.Input;
using Code.Gameplay.Physics;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Players
{
    public class PlayerMover : MonoBehaviour
    {
        private float _rotationSpeed;
        private float _thrustAcceleration;
        private float _maxSpeed;
        private float _angularVelocity;

        private IInputService _inputService;
        private PhysicsBody2D _body2D;

        [Inject]
        public void Construct(IInputService inputService)
            => _inputService = inputService;

        private void Awake()
            => _body2D = GetComponent<PhysicsBody2D>();

        private void Update()
            => _angularVelocity = -_inputService.Rotation * _rotationSpeed;

        private void FixedUpdate()
        {
            if (_inputService.Forward > 0f)
            {
                _body2D.SetVelocity(CustomPhysicsEngine.AddForce(
                    _body2D.Velocity.CurrentValue, transform.up * _thrustAcceleration * _inputService.Forward,
                    _body2D.Mass, Time.fixedDeltaTime, _maxSpeed));
            }

            transform.position =
                CustomPhysicsEngine.MovePosition(transform.position, _body2D.Velocity.CurrentValue, Time.fixedDeltaTime);
            transform.rotation =
                CustomPhysicsEngine.MoveRotation(transform.rotation, _angularVelocity, Time.fixedDeltaTime);
        }

        public void Init(float rotationSpeed, float thrustAcceleration, float maxSpeed)
        {
            _rotationSpeed = rotationSpeed;
            _thrustAcceleration = thrustAcceleration;
            _maxSpeed = maxSpeed;
        }
    }
}