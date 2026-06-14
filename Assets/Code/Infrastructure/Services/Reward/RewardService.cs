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
            foreach (var rewardConfig in _configService.Rewards.EnemyKillRewards)
                _rewards[rewardConfig.EnemyType] = rewardConfig.Reward;
        }

        public void GiveReward(EnemyType type)
        {
            if (_rewards.TryGetValue(type, out int reward))
                _scoreService.AddScore(reward);
        }
    }
}