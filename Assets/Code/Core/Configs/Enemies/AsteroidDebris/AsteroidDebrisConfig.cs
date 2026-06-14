using Code.Core.Configs.Enemies.Asteroid;
using Code.Core.Configs.Player;
using Code.Core.Configs.Rewards;

namespace Code.Core.Configs.Enemies.AsteroidDebris
{
    public class AsteroidDebrisConfig : IConfigValidate
    {
        public PhysicsConfig Physics;
        public AsteroidMoverConfig Mover;
        public RewardConfig Reward;
        
        public void Validate()
        {
            Physics.Validate();
            Mover.Validate();
            Reward.Validate();
        }
    }
}