using Code.Core.BaseEnemies;
using Code.Core.Interfaces.ConfigServices;
using Code.Gameplay.Enemies;
using Code.Infrastructure.Services.StaticData;
using Code.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Factories.EnemyFactories
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IStaticDataService _staticDataService;
        private readonly IConfigService _configService;

        public EnemyFactory(IInstantiator instantiator, IStaticDataService staticDataService,
            IConfigService configService)
        {
            _instantiator = instantiator;
            _staticDataService = staticDataService;
            _configService = configService;
        }

        public GameObject CreateEnemy(EnemyType type)
        {
            var prefab = _staticDataService.GetEnemyData(type).Prefab;
            GameObject enemy = _instantiator.InstantiatePrefab(prefab);

            enemy.GetComponent<BaseEnemy>().InitType(type);

            if (enemy.TryGetComponent<IEnemyConfigurator>(out var configurator))
                configurator.Configure(_configService.Enemies);

            return enemy;
        }
    }
}