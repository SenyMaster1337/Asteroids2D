using Code.Gameplay.PlayerProviders;
using MVVM;
using R3;
using Zenject;

namespace Code.UI.ViewModels
{
    public class RotationAngleViewModel : ITickable
    {
        [Data("RotationAngle")] 
        public readonly ReactiveProperty<string> Rotation = new();

        private readonly IPlayerProvider _playerProvider;

        public RotationAngleViewModel(IPlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
        }

        public void Tick()
        {
            if (_playerProvider.Player == null)
                return;

            var pos = _playerProvider.Player.transform.eulerAngles.z;
            Rotation.Value = $"{pos:F1}";
        }
    }
}