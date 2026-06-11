using System.Collections.Generic;
using Code.Core.Interfaces.ConfigServices;
using Code.Core.Interfaces.Score;
using Code.StaticData;
using Zenject;

namespace Code.Infrastructure.Services.Reward
{
    public class RewardService : IRewardService, IInitializable
    {
        private readonly IConfigService _configService;
        private readonly IScoreService _scoreService;
        private readonly Dictionary<EnemyType, int> _rewards = new();

        public RewardService(IConfigService configService, IScoreService scoreService)
        {
            _configService = configService;
            _scoreService = scoreService;
        }

        public void Initialize()
        {
            var enemiesConfig = _configService.Enemies;

            _rewards[EnemyType.Asteroid] = enemiesConfig.Asteroid.Reward.RewardToDestructionValue;
            _rewards[EnemyType.AsteroidDebris] = enemiesConfig.AsteroidDebris.Reward.RewardToDestructionValue;
            _rewards[EnemyType.AlienShip] = enemiesConfig.AlienShip.Reward.RewardToDestructionValue;
        }

        public void GiveReward(EnemyType type)
        {
            if (_rewards.TryGetValue(type, out int reward))
                _scoreService.AddScore(reward);
        }
    }
}