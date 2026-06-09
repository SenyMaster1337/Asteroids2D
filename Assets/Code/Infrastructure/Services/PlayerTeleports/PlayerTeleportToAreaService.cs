using System;
using Code.Gameplay.Area;
using UnityEngine;

namespace Code.Infrastructure.Services.PlayerTeleports
{
    public class PlayerTeleportToAreaService : IPlayerTeleportService, IDisposable
    {
        private readonly IGameAreaProvider _gameAreaProvider;
        private GameArea _area;

        public PlayerTeleportToAreaService(IGameAreaProvider gameAreaProvider)
        {
            _gameAreaProvider = gameAreaProvider;
        }

        public void Init()
        {
            _gameAreaProvider.GameArea.PlayerExited += OnPlayerExited;
            _area = _gameAreaProvider.GameArea;
        }

        public void Dispose()
            => _gameAreaProvider.GameArea.PlayerExited -= OnPlayerExited;

        private void OnPlayerExited(Transform playerTransform)
        {
            Vector3 position = playerTransform.position;

            position.x = position.x > _area.MaxX ? _area.MinX
                : position.x < _area.MinX ? _area.MaxX
                : position.x;

            position.y = position.y > _area.MaxY ? _area.MinY
                : position.y < _area.MinY ? _area.MaxY
                : position.y;

            playerTransform.position = position;
        }
    }
}