using System;
using Code.Gameplay.PlayerProviders;
using MVVM;
using R3;
using Zenject;

namespace Code.UI.ViewModels
{
    public class LaserChargesViewModel : IInitializable, IDisposable
    {
        [Data("LaserCharges")] 
        public readonly ReactiveProperty<string> Charges = new();

        private readonly IPlayerProvider _playerProvider;
        private IDisposable _subscription;

        public LaserChargesViewModel(IPlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
        }

        public void Initialize()
        {
            var shooter = _playerProvider.Player.PlayerLaserShooter;
            Charges.Value = shooter.Charges.Value.ToString();
            _subscription = shooter.Charges.Subscribe(value => Charges.Value = value.ToString());
        }

        public void Dispose()
            => _subscription?.Dispose();
    }
}