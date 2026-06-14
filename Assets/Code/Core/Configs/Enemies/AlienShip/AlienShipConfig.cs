using Code.Core.Configs.Player;
using Code.Core.Configs.Rewards;

namespace Code.Core.Configs.Enemies.AlienShip
{
    public class AlienShipConfig : IConfigValidate
    {
        public PhysicsConfig Physics;
        public AlienShipFollowerConfig Follower;
        public RewardConfig Reward;
        
        public void Validate()
        {
            Physics.Validate();
            Follower.Validate();
            Reward.Validate();
        }
    }
}