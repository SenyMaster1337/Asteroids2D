using System;
using Code.Core.Interfaces.Enemy;
using Code.StaticData;
using UnityEngine;

namespace Code.Gameplay.Enemies.Asteroids
{
    public class AsteroidDebris : MonoBehaviour, IEnemy
    {
        private AsteroidMover _asteroidMover;

        public GameObject GameObject { get; private set; }
        public EnemyType Type { get; private set; }

        public event Action<IEnemy> Dead;
        public event Action<IEnemy> Expired;

        private void Awake()
        {
            GameObject = gameObject;
            _asteroidMover = GetComponent<AsteroidMover>();
        }

        public void SetType(EnemyType type)
            => Type = type;

        public void Launch() 
            => _asteroidMover.Launch(true);

        public void ReturnToPool()
            => Expired?.Invoke(this);

        public void Die()
            => Dead?.Invoke(this);

        public void ResetVelocity()
            => _asteroidMover.ResetVelocity();
    }
}