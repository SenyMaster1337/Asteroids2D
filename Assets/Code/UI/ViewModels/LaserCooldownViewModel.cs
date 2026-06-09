using System;
using Code.Gameplay.PlayerProviders;
using MVVM;
using R3;
using Zenject;

namespace Code.UI.ViewModels
{
    public class LaserCooldownViewModel : IInitializable, IDisposable
    {
        [Data("LaserCooldown")]
        public readonly ReactiveProperty<string> Cooldown = new();

        private readonly IPlayerProvider _playerProvider;
        private IDisposable _subscription;

        public LaserCooldownViewModel(IPlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
        }

        public void Initialize()
        {
            var shooter = _playerProvider.Player.PlayerLaserShooter;
            Cooldown.Value = $"{shooter.CooldownRemaining.Value:F2}";
            _subscription = shooter.CooldownRemaining.Subscribe(value => Cooldown.Value = $"{value:F2}");
        }

        public void Dispose()
            => _subscription?.Dispose();
    }
}