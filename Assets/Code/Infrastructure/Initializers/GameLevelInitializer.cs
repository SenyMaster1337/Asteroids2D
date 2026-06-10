using Code.Core.CameraProviders;
using Code.Gameplay;
using Code.Infrastructure.Factories.AreaFactories;
using Code.Infrastructure.Factories.PlayerFactories;
using Code.Infrastructure.Factories.UIFactories;
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
        private readonly IPlayerFactory _playerFactory;
        private readonly IGameAreaFactory _gameAreaFactory;
        private readonly IUIFactory _uiFactory;
        private readonly IPlayerTeleportService _playerTeleportService;
        private readonly ILoseService _loseService;
        private readonly ICameraProvider _cameraProvider;
        private readonly IConfigService _configService;

        public GameLevelInitializer(IEnemyWaveService enemyWaveService, IPlayerFactory playerFactory,
            IGameAreaFactory gameAreaFactory, IUIFactory uiFactory, IPlayerTeleportService playerTeleportService,
            ILoseService loseService, ICameraProvider cameraProvider, IConfigService configService)
        {
            _enemyWaveService = enemyWaveService;
            _playerFactory = playerFactory;
            _gameAreaFactory = gameAreaFactory;
            _uiFactory = uiFactory;
            _playerTeleportService = playerTeleportService;
            _loseService = loseService;
            _cameraProvider = cameraProvider;
            _configService = configService;
        }

        public void Initialize()
        {
            _gameAreaFactory.CreateGameArea();
            _playerFactory.CreatePlayer();
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

            _enemyWaveService.StartWave();
        }
    }
}