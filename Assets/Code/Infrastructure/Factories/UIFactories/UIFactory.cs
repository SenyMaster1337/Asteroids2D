using Code.Core.ConfigLoaders;
using Code.Core.Interfaces.ConfigServices;
using Code.Infrastructure.AssetManagement;
using Code.UI.Views;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Factories.UIFactories
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;
        private readonly IConfigService _configService;

        private GameObject _uiRoot;

        public UIFactory(IAssetProvider assetProvider, IConfigService configService, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _configService = configService;
            _instantiator = instantiator;
        }

        public GameObject CreateUIRoot()
        {
            var uiRootPrefab = _assetProvider.Load(AssetPath.UIRootPath);

            _uiRoot = _instantiator.InstantiatePrefab(uiRootPrefab);

            return _uiRoot;
        }

        public GameObject CreateHud()
        {
            var hudPrefab = _assetProvider.Load(AssetPath.HudPath);

            return _instantiator.InstantiatePrefab(hudPrefab, _uiRoot.transform);
        }

        public GameObject CreateMobileInput()
        {
            var mobileInputPrefab = _assetProvider.Load(AssetPath.MobileInputPath);

            return _instantiator.InstantiatePrefab(mobileInputPrefab, _uiRoot.transform);
        }

        public GameObject CreatePlayerHealthView()
        {
            var healthPrefab = _assetProvider.Load(AssetPath.PlayerHealthViewPath);

            GameObject prefab = _instantiator.InstantiatePrefab(healthPrefab, _uiRoot.transform);
            PlayerHealthConfig healthConfig = _configService.Player.Health;

            var healthView = prefab.GetComponent<HealthView>();

            for (int i = 0; i < healthConfig.MaxHealth; i++)
                healthView.AddHeart(CreateHeartView(prefab.transform));

            return prefab.gameObject;
        }

        public GameObject CreateControlsInstruction()
        {
            var instructionPrefab = _assetProvider.Load(AssetPath.ControlsInstructionPath);

            return _instantiator.InstantiatePrefab(instructionPrefab, _uiRoot.transform);
        }

        public GameObject CreateStartView()
        {
            var buttonPrefab = _assetProvider.Load(AssetPath.StartButtonPath);

            return _instantiator.InstantiatePrefab(buttonPrefab, _uiRoot.transform);
        }

        public GameObject CreateRestartView()
        {
            var restartWindow = _assetProvider.Load(AssetPath.RestartButtonPath);

            return _instantiator.InstantiatePrefab(restartWindow, _uiRoot.transform);
        }

        private GameObject CreateHeartView(Transform parent)
        {
            var heartPrefab = _assetProvider.Load(AssetPath.HeartViewPath);

            return _instantiator.InstantiatePrefab(heartPrefab, parent);
        }
    }
}