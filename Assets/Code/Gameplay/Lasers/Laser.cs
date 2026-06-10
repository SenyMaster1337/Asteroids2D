using System;
using Code.Core.Interfaces.Enemy;
using Code.Gameplay.Enemies;
using UnityEngine;

namespace Code.Gameplay.Lasers
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Laser : MonoBehaviour
    {
        private float _duration;
        private float _timer;

        public event Action Expired;

        private void Awake()
            => GetComponent<BoxCollider2D>().isTrigger = true;

        private void OnEnable()
            => _timer = _duration;

        private void Update()
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0f)
                Expired?.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<IEnemy>(out var enemy))
                enemy.Die();
        }

        public void Init(float duration) 
            => _duration = duration;
    }
}