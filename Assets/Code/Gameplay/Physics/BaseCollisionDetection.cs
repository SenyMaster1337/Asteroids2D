using System;
using Code.StaticData;
using UnityEngine;

namespace Code.Gameplay.Physics
{
    public abstract class BaseCollisionDetection : MonoBehaviour, ICollisionDetection
    {
        [SerializeField] private LayerMaskTypeId _targetLayer;

        protected int _layerMask;
        protected readonly Collider2D[] _results = new Collider2D[10];

        public event Action<Collider2D> Collided;

        private void Awake()
        {
            _layerMask = 1 << (int)_targetLayer;
            OnAwake();
        }

        protected abstract void OnAwake();

        protected void InvokeCollided(Collider2D collider) =>
            Collided?.Invoke(collider);
    }
}