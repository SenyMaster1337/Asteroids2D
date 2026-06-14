using System.Collections.Generic;

namespace Code.Core.Configs.Rewards
{
    public class RewardsConfig : IConfigValidate
    {
        public List<EnemyKillRewardConfig> EnemyKillRewards;

        public void Validate()
        {
            foreach (var enemyKillReward in EnemyKillRewards)
                enemyKillReward.Validate();
        }
    }
}