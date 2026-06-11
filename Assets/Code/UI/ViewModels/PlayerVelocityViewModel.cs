using System;
using Code.Gameplay.PlayerProviders;
using MVVM;
using R3;
using Zenject;

namespace Code.UI.ViewModels
{
    public class PlayerVelocityViewModel : IInitializable, IDisposable
    {
        [Data("Velocity")] 
        public readonly ReactiveProperty<string> Velocity = new();

        private readonly IPlayerProvider _playerProvider;
        private IDisposable _subscription;

        public PlayerVelocityViewModel(IPlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
        }

        public void Initialize()
        {
            var body = _playerProvider.Player.PlayerPhysicsBody2D;
            Velocity.Value = $"{body.Velocity.CurrentValue.magnitude:F2}";
            _subscription = body.Velocity.Subscribe(value => Velocity.Value = $"{value.magnitude:F2}");
        }

        public void Dispose() 
            => _subscription?.Dispose();
    }
}