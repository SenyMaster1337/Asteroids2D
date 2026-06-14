using System;

namespace Code.Core.Configs.Enemies.Asteroid
{
    public class AsteroidMoverConfig : IConfigValidate
    {
        public float Speed;
        public float RotationSpeed;

        public void Validate()
        {
            if (Speed < 0)
                throw new Exception("Asteroid Speed must be >= 0");

            if (RotationSpeed < 0)
                throw new Exception("Asteroid RotationSpeed must be >= 0");
        }
    }
}