using System;
using Code.StaticData;
using UnityEngine;

namespace Code.Core.BaseEnemies
{
    public abstract class BaseEnemy : MonoBehaviour
    {
        public EnemyType Type { get; private set; }

        public event Action<BaseEnemy> Dead;
        public event Action<BaseEnemy> Expired;

        private bool _isDead;

        private void Awake()
            => OnAwake();

        protected virtual void OnAwake() { }

        public void InitType(EnemyType type)
            => Type = type;

        public abstract void Launch();

        public virtual void Die() 
            => Dead?.Invoke(this);

        public void InvokeExpired()
            => Expired?.Invoke(this);

        public virtual void Reset()
            => _isDead = false;

        protected bool TryMarkDead()
        {
            if (_isDead)
                return false;

            _isDead = true;
            return true;
        }
    }
}