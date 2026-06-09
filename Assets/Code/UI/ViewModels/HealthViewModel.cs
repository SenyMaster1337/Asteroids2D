using System;
using Code.Gameplay.PlayerProviders;
using MVVM;
using R3;
using Zenject;

namespace Code.UI.ViewModels
{
    public class HealthViewModel : IInitializable, IDisposable
    {
        [Data("Health")] 
        public readonly ReactiveProperty<int> Health = new();
 
        private readonly IPlayerProvider _playerProvider;

        private IDisposable _subscription;

        public HealthViewModel(IPlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
        }

        public void Initialize()
        {
            var health = _playerProvider.Player.Health.Current;
            Health.Value = health.CurrentValue;
            _subscription = health.Subscribe(value => Health.Value = value);
        }

        public void Dispose()
            => _subscription?.Dispose();
    }
}