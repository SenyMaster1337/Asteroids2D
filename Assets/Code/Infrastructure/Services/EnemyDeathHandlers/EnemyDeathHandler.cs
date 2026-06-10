using System;
using Code.Core.BaseEnemies;
using Code.Core.Interfaces.Spawners;
using Code.Infrastructure.Services.Reward;
using Zenject;

namespace Code.Infrastructure.Services.EnemyDeathHandlers
{
    public class EnemyDeathHandler : IInitializable, IDisposable, IEnemyDeathHandler
    {
        private readonly IRewardService _rewardService;
        private readonly IEnemySpawnerService _enemySpawner;

        public EnemyDeathHandler(IRewardService rewardService, IEnemySpawnerService enemySpawner)
        {
            _rewardService = rewardService;
            _enemySpawner = enemySpawner;
        }

        public void Initialize()
            => _enemySpawner.EnemyDied += OnEnemyDied;

        public void Dispose()
            => _enemySpawner.EnemyDied -= OnEnemyDied;

        private void OnEnemyDied(BaseEnemy enemy)
            => _rewardService.GiveReward(enemy.Type);
    }
}