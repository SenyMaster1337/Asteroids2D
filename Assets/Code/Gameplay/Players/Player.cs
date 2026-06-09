using System;
using Code.Gameplay.Lasers;
using Code.Gameplay.Physics;
using Code.Gameplay.PlayerProviders;
using R3;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Players
{
    public class Player : MonoBehaviour
    {
        public Health Health { get; private set; } = new();
        public PlayerLaserShooter PlayerLaserShooter { get; private set; }
        public PhysicsBody2D PlayerPhysicsBody2D { get; private set; }

        public event Action Died;
        
        private IPlayerProvider _playerProvider;
        private IDisposable _healthSubscription;

        [Inject]
        private void Construct(IPlayerProvider playerProvider)
            => _playerProvider = playerProvider;

        private void Awake()
        {
            PlayerLaserShooter = GetComponent<PlayerLaserShooter>();
            PlayerPhysicsBody2D = GetComponent<PhysicsBody2D>();
            _playerProvider.SetPlayer(this);
        }

        private void Start()
            => _healthSubscription = Health.Current.Subscribe(OnHealthChanged);

        private void OnDestroy()
            => _healthSubscription?.Dispose();

        private void OnHealthChanged(int current)
        {
            if (current <= 0)
            {
                Died?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}