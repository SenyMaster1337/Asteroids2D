using Code.Core.Interfaces.ConfigServices;
using Code.Gameplay.Area;
using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Factories.AreaFactories
{
    public class GameAreaFactory : IGameAreaFactory
    {
        private const float EnemyBoundaryAreaOffset = 8f;

        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;
        private readonly IConfigService _configService;

        public GameAreaFactory(IAssetProvider assetProvider, IInstantiator instantiator, IConfigService configService)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
            _configService = configService;
        }

        public GameObject CreateGameArea()
        {
            var prefab = _assetProvider.Load(AssetPath.GameAreaPath);
            GameObject area = _instantiator.InstantiatePrefab(prefab);

            var areaConfig = _configService.Area;

            area.GetComponent<GameArea>().Init(areaConfig.WorldWidth, areaConfig.WorldHeight);
            area.GetComponentInChildren<EnemyBoundaryArea>().Init(
                areaConfig.WorldWidth + EnemyBoundaryAreaOffset,
                areaConfig.WorldHeight + EnemyBoundaryAreaOffset);

            return area;
        }
    }
}