using System;

namespace Code.Core.Configs.Player
{
    public class PlayerMoverConfig : IConfigValidate
    {
        public float ThrustAcceleration;
        public float MaxSpeed;
        public float RotationSpeed;

        public void Validate()
        {
            if (MaxSpeed <= 0)
                throw new Exception("MaxSpeed must be > 0");

            if (ThrustAcceleration <= 0)
                throw new Exception("ThrustAcceleration must be > 0");

            if (RotationSpeed < 0)
                throw new Exception("RotationSpeed must be >= 0");
        }
    }
}