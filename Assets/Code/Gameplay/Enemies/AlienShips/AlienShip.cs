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
        
        public override void Die()
        {
            if (TryMarkDead() == false) 
                return;

            base.Die();
        }

        public override void Reset()
        {
            base.Reset();
            _body2D.SetVelocity(Vector2.zero);
        }
    }
}