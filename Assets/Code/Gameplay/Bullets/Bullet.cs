using System;
using Code.Gameplay.Enemies;
using UnityEngine;

namespace Code.Gameplay.Bullets
{
    public class Bullet : MonoBehaviour
    {
        public event Action<Bullet> Expired;

        private float _lifetime;
        private float _speed;
        private Vector2 _direction;
        private float _timer;

        private void Awake()
            => GetComponent<BoxCollider2D>().isTrigger = true;

        private void OnEnable()
            => _timer = _lifetime;

        public void SetDirection(Vector2 direction)
            => _direction = direction;

        private void Update()
        {
            transform.Translate(_direction * (_speed * Time.deltaTime), Space.World);

            _timer -= Time.deltaTime;

            if (_timer <= 0f)
                Expired?.Invoke(this);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<IEnemy>(out var enemy))
            {
                enemy.Die();
                Expired?.Invoke(this);
            }
        }

        public void Init(float lifetime, float speed)
        {
            _lifetime = lifetime;
            _speed = speed;
        }
    }
}