using Code.Gameplay.PlayerProviders;
using MVVM;
using R3;
using Zenject;

namespace Code.UI.ViewModels
{
    public class PlayerCoordinatesViewModel : ITickable
    {
        [Data("Coordinates")] 
        public readonly ReactiveProperty<string> Coordinates = new();

        private readonly IPlayerProvider _playerProvider;

        public PlayerCoordinatesViewModel(IPlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
        }

        public void Tick()
        {
            if (_playerProvider.Player == null)
                return;

            var pos = _playerProvider.Player.transform.position;
            Coordinates.Value = $"X: {pos.x:F1} Y: {pos.y:F1}";
        }
    }
}