using Code.Gameplay.Enemies;
using UnityEngine;

namespace Code.Gameplay.Area
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class EnemyBoundaryArea : MonoBehaviour
    {
        private BoxCollider2D _collider;
        private float _width;
        private float _height;
        
        private void Awake()
        {
            _collider = GetComponent<BoxCollider2D>();
            _collider.isTrigger = true;
        }
        
        public void Init(float width, float height)
        {
            _width = width;
            _height = height;

            _collider.size = new Vector2(_width, _height);
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent<IEnemy>(out var enemy))
                enemy.ReturnToPool();
        }
    }
}