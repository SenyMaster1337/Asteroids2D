using Code.Infrastructure.Services.ConfigLoaders.Player;
using Code.Infrastructure.Services.ConfigLoaders.Rewards;

namespace Code.Infrastructure.Services.ConfigLoaders.Enemies.AlienShip
{
    public class AlienShipConfig
    {
        public PhysicsConfig Physics;
        public AlienShipFollowerConfig Follower;
        public RewardConfig Reward;
    }
}