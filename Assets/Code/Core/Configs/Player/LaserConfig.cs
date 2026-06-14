using System;

namespace Code.Core.Configs.Player
{
    public class LaserConfig : IConfigValidate
    {
        public float Lifetime;
        public int MaxCharges;
        public float Cooldown;
        public float FireRate;

        public void Validate()
        {
            if (Lifetime <= 0)
                throw new Exception("Laser Lifetime must be > 0");

            if (MaxCharges <= 0)
                throw new Exception("Laser MaxCharges must be > 0");

            if (Cooldown <= 0)
                throw new Exception("Laser Cooldown must be > 0");

            if (FireRate <= 0)
                throw new Exception("Laser FireRate must be > 0");
        }
    }
}