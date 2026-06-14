using System;
using Code.Core.Configs.Player;

namespace Code.Core.Configs.Enemies.Asteroid
{
    public class AsteroidConfig : IConfigValidate
    {
        public int AsteroidDebrisCount;
        public AsteroidMoverConfig Mover;
        public PhysicsConfig Physics;

        public void Validate()
        {
            if (AsteroidDebrisCount < 0)
                throw new Exception("AsteroidDebrisCount must be >= 0");

            Mover.Validate();
            Physics.Validate();
        }
    }
}