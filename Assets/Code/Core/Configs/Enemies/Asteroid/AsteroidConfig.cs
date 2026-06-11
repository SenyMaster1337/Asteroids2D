using Code.Infrastructure.Services.ConfigLoaders.Player;
using Code.Infrastructure.Services.ConfigLoaders.Rewards;

namespace Code.Core.Configs.Enemies.Asteroid
{
    public class AsteroidConfig
    {
        public int AsteroidDebrisCount;
        public AsteroidMoverConfig Mover;
        public PhysicsConfig Physics;
        public RewardConfig Reward;
    }
}