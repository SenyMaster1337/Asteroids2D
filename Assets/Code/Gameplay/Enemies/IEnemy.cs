using System;
using Code.StaticData;
using UnityEngine;

namespace Code.Gameplay.Enemies
{
    public interface IEnemy
    {
        public EnemyType Type { get; }
        public GameObject GameObject { get; }
        public event Action<IEnemy> Dead;
        public event Action<IEnemy> Expired;
        void Launch();
        void ResetVelocity();
        void Die();
        void ReturnToPool();
        void SetType(EnemyType type);
    }
}