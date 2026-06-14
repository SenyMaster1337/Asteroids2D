using Code.Core.Configs.Enemies.Asteroid;
using Code.Core.Configs.Player;

namespace Code.Core.Configs.Enemies.AsteroidDebris
{
    public class AsteroidDebrisConfig : IConfigValidate
    {
        public PhysicsConfig Physics;
        public AsteroidMoverConfig Mover;

        public void Validate()
        {
            Physics.Validate();
            Mover.Validate();
        }
    }
}