using Code.Core.CameraProviders;
using Code.Gameplay;
using Code.Infrastructure.Factory.Game;
using Code.Infrastructure.Factory.UI;
using Code.Infrastructure.Services.ConfigLoaders.Area;
using Code.Infrastructure.Services.ConfigServices;
using Code.Infrastructure.Services.EnemyWave;
using Code.Infrastructure.Services.LoseServices;
using Code.Infrastructure.Services.PlayerTeleports;
using Zenject;

namespace Code.Infrastructure.Initializers
{
    public class GameLevelInitializer : IInitializable
    {
        private readonly IEnemyWaveService _enemyWaveService;
        private readonly IGameFactory _gameFactory;
        private readonly IUIFactory _uiFactory;
        private readonly IPlayerTeleportService _playerTeleportService;
        private readonly ILoseService _loseService;
        private readonly ICameraProvider _cameraProvider;
        private readonly IConfigService _configService;

        public GameLevelInitializer(IEnemyWaveService enemyWaveService, IGameFactory gameFactory, IUIFactory uiFactory,
            IPlayerTeleportService playerTeleportService, ILoseService loseService, ICameraProvider cameraProvider,
            IConfigService configService)
        {
            _enemyWaveService = enemyWaveService;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
            _playerTeleportService = playerTeleportService;
            _loseService = loseService;
            _cameraProvider = cameraProvider;
            _configService = configService;
        }

        public void Initialize()
        {
            _gameFactory.CreateGameArea();
            _gameFactory.CreatePlayer();
            _uiFactory.CreateUIRoot();
            _uiFactory.CreateHud();
            _uiFactory.CreatePlayerHealthView();

#if UNITY_ANDROID || UNITY_IOS
    _uiFactory.CreateMobileInput();
#endif

            _playerTeleportService.Init();
            _loseService.Init();
            AreaConfig areaConfig = _configService.Area;
            _cameraProvider.Camera.GetComponent<CameraZoom>().Init(areaConfig.WorldWidth, areaConfig.WorldHeight);

            _enemyWaveService.Start();
        }
    }
}