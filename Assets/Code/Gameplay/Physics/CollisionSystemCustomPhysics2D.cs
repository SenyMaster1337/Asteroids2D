using System.Collections.Generic;
using UnityEngine;
using Code.Core.Tools;

namespace Code.Gameplay.Physics
{
    public static class CollisionSystemCustomPhysics2D
    {
        private static readonly List<Collider2D> _colliders = new();

        public static void Register(Collider2D collider)
            => _colliders.Add(collider);

        public static void Unregister(Collider2D collider)
            => _colliders.Remove(collider);

        public static int OverlapCircle(Vector2 point, float radius, Collider2D[] results, int layerMask)
        {
            return Overlap(point, radius, results, layerMask);
        }

        public static int OverlapBox(Vector2 point, Vector2 size, Collider2D[] results, int layerMask)
        {
            float radius = size.magnitude * 0.5f;
            return Overlap(point, radius, results, layerMask);
        }

        private static int Overlap(Vector2 point, float radius, Collider2D[] results, int layerMask)
        {
            int count = 0;

            for (int i = 0; i < _colliders.Count; i++)
            {
                Collider2D col = _colliders[i];
                if (col == null || !col.gameObject.activeInHierarchy)
                    continue;

                if (layerMask != 0 && (layerMask & (1 << col.gameObject.layer)) == 0)
                    continue;

                float colRadius = GetRadius(col);
                float sqrDistance = point.SqrMagnitudeTo(col.transform.position);
                float sqrTotal = (radius + colRadius) * (radius + colRadius);

                if (sqrDistance <= sqrTotal)
                {
                    results[count] = col;
                    count++;
                    if (count >= results.Length)
                        break;
                }
            }

            return count;
        }

        private static float GetRadius(Collider2D col)
        {
            return col switch
            {
                CircleCollider2D c => c.radius,
                BoxCollider2D b => b.size.magnitude * 0.5f,
                _ => col.bounds.size.magnitude * 0.5f
            };
        }
    }
}