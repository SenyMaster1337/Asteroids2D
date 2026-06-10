using Code.Core.BaseEnemies;
using Code.Gameplay.Physics;
using UnityEngine;

namespace Code.Gameplay.Enemies.AlienShips
{
    public class AlienShip : BaseEnemy
    {
        private AlienShipFollower _alienShipFollower;
        private PhysicsBody2D _body2D;

        protected override void OnAwake()
        {
            base.OnAwake();
            _alienShipFollower = GetComponent<AlienShipFollower>();
            _body2D = GetComponent<PhysicsBody2D>();
        }

        public override void Launch()
            => _alienShipFollower.Launch();

        public override void ResetVelocity()
            => _body2D.Velocity.Value = Vector2.zero;
    }
}