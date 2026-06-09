using Code.Gameplay.PlayerProviders;
using Code.Infrastructure.Factory.UI;
using Zenject;

namespace Code.Infrastructure.Services.LoseServices
{
    public class LoseService : ILoseService, ILateDisposable
    {
        private readonly IUIFactory _uiFactory;
        private readonly IPlayerProvider _playerProvider;

        public LoseService(IUIFactory uiFactory, IPlayerProvider playerProvider)
        {
            _uiFactory = uiFactory;
            _playerProvider = playerProvider;
        }

        public void Init()
            => _playerProvider.Player.Died += OnPlayerDied;

        public void LateDispose()
            => _playerProvider.Player.Died -= OnPlayerDied;

        private void OnPlayerDied()
            => _uiFactory.CreateRestartView();
    }
}