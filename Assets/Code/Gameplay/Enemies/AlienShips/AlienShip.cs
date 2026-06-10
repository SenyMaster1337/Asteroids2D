using System;
using Code.Core.Interfaces.Enemy;
using Code.Gameplay.Physics;
using Code.StaticData;
using UnityEngine;

namespace Code.Gameplay.Enemies.AlienShips
{
    public class AlienShip : MonoBehaviour, IEnemy
    {
        public GameObject GameObject { get; private set; }
        public EnemyType Type { get; private set; }

        public event Action<IEnemy> Dead;
        public event Action<IEnemy> Expired;

        private AlienShipFollower _alienShipFollower;
        private PhysicsBody2D _body2D;

        protected void Awake()
        {
            GameObject = gameObject;
            _alienShipFollower = GetComponent<AlienShipFollower>();
            _body2D = GetComponent<PhysicsBody2D>();
        }

        public void SetType(EnemyType type)
            => Type = type;

        public void Launch()
            => _alienShipFollower.Launch();

        public void Die()
            => Dead?.Invoke(this);

        public void ReturnToPool()
            => Expired?.Invoke(this);

        public void ResetVelocity()
            => _body2D.Velocity.Value = Vector2.zero;
    }
}