using System;
using Code.StaticData;

namespace Code.Core.Configs.Rewards
{
    public class EnemyKillRewardConfig : IConfigValidate
    {
        public EnemyType EnemyType;
        public int Reward;

        public void Validate()
        {
            if (EnemyType == EnemyType.None)
                throw new Exception("Reward EnemyType cannot be None");

            if (Reward < 0)
                throw new Exception("Reward must be >= 0");
        }
    }
}