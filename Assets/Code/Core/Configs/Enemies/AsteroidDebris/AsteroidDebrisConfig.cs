using Code.Core.Configs.Enemies.Asteroid;
using Code.Infrastructure.Services.ConfigLoaders.Player;
using Code.Infrastructure.Services.ConfigLoaders.Rewards;

namespace Code.Core.Configs.Enemies.AsteroidDebris
{
    public class AsteroidDebrisConfig
    {
        public PhysicsConfig Physics;
        public AsteroidMoverConfig Mover;
        public RewardConfig Reward;
    }
}