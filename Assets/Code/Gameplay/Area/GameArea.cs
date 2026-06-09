using System;
using Code.Gameplay.Players;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Area
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class GameArea : MonoBehaviour
    {
        private float _width;
        private float _height;

        public event Action<Transform> PlayerExited;

        private BoxCollider2D _collider;
        private IGameAreaProvider _gameAreaProvider;

        public float MinX => -_width / 2f;
        public float MaxX => _width / 2f;
        public float MinY => -_height / 2f;
        public float MaxY => _height / 2f;

        [Inject]
        public void Construct(IGameAreaProvider gameAreaProvider)
            => _gameAreaProvider = gameAreaProvider;

        public void Init(float width, float height)
        {
            _width = width;
            _height = height;

            _collider.size = new Vector2(_width, _height);
        }

        private void Awake()
        {
            _collider = GetComponent<BoxCollider2D>();
            _collider.isTrigger = true;

            _gameAreaProvider.SetGameArea(this);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent<Player>(out var player))
                PlayerExited?.Invoke(player.transform);
        }
    }
}