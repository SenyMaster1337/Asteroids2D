using System;

namespace Code.Core.Configs.Rewards
{
    public class RewardConfig : IConfigValidate
    {
        public int RewardToDestructionValue;
        
        public void Validate()
        {
            if (RewardToDestructionValue < 0) 
                throw new Exception("Reward must be >= 0");
        }
    }
}