using UnityEngine;

namespace Code.Gameplay.Physics
{
    public class EnemyCollisionDetection : BaseCollisionDetection
    {
        private CircleCollider2D _collider;

        protected override void OnAwake() =>
            _collider = GetComponent<CircleCollider2D>();

        private void FixedUpdate()
        {
            int hits = CollisionSystemCustomPhysics2D.OverlapCircle(
                transform.position, _collider.radius, _results, _layerMask);

            for (int i = 0; i < hits; i++)
            {
                if (_results[i] == _collider || _results[i].isTrigger)
                    continue;

                InvokeCollided(_results[i]);
                return;
            }
        }

        private void OnEnable()
            => CollisionSystemCustomPhysics2D.Register(_collider);

        private void OnDisable()
            => CollisionSystemCustomPhysics2D.Unregister(_collider);
    }
}