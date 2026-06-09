using Code.Gameplay.Physics;
using Code.Gameplay.PlayerProviders;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Enemies.AlienShips
{
    public class AlienShipFollower : MonoBehaviour
    {
        private float _speed;
        private float _agility;

        private PhysicsBody2D _body2D;
        private IPlayerProvider _playerProvider;

        [Inject]
        public void Construct(IPlayerProvider playerProvider) 
            => _playerProvider = playerProvider;

        private void Awake() =>
            _body2D = GetComponent<PhysicsBody2D>();

        private void FixedUpdate()
        {
            if (_playerProvider.Player == null)
            {
                MoveBody();
                return;
            }

            Vector2 desired = DirectionTo(_playerProvider.Player.transform.position) * _speed;
            _body2D.Velocity.Value = Vector2.Lerp(_body2D.Velocity.Value, desired, Time.fixedDeltaTime * _agility);
            MoveBody();
        }

        public void Launch()
        {
            if (_playerProvider.Player == null)
            {
                _body2D.Velocity.Value = Random.insideUnitCircle.normalized * _speed;
                return;
            }

            _body2D.Velocity.Value = DirectionTo(_playerProvider.Player.transform.position) * _speed;
        }

        public void Init(float speed, float agility)
        {
            _speed = speed;
            _agility = agility;
        }

        private void MoveBody() =>
            transform.position = CustomPhysicsEngine.MovePosition(
                transform.position, _body2D.Velocity.Value, Time.fixedDeltaTime);

        private Vector2 DirectionTo(Vector3 target) =>
            (target - transform.position).normalized;
    }
}