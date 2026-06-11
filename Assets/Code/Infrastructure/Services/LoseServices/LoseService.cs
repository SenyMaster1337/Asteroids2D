using Code.Gameplay.PlayerProviders;
using Code.Infrastructure.Factories.UIFactories;

namespace Code.Infrastructure.Services.LoseServices
{
    public class LoseService : ILoseService
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

        private void OnPlayerDied()
        {
            _playerProvider.Player.Died -= OnPlayerDied;
            _uiFactory.CreateRestartView();
        }
    }
}