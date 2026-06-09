using UnityEngine;

namespace Code.Gameplay.Physics
{
    public class PlayerCollisionDetection : BaseCollisionDetection
    {
        private BoxCollider2D _collider;

        private void FixedUpdate()
        {
            if (_collider.isTrigger)
                return;

            int hits = CollisionSystemCustomPhysics2D.OverlapBox(
                transform.position, _collider.size, _results, _layerMask);

            for (int i = 0; i < hits; i++)
            {
                if (_results[i] == _collider)
                    continue;

                InvokeCollided(_results[i]);
                
                return;
            }
        }

        private void OnEnable()
            => CollisionSystemCustomPhysics2D.Register(_collider);

        private void OnDisable()
            => CollisionSystemCustomPhysics2D.Unregister(_collider);

        public void EnableDetection() 
            => _collider.isTrigger = false;

        public void DisableDetection() 
            => _collider.isTrigger = true;

        protected override void OnAwake() 
            => _collider = GetComponent<BoxCollider2D>();
    }
}