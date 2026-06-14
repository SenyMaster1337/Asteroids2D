using System;

namespace Code.Core.Configs.Player
{
    public class BulletConfig : IConfigValidate
    {
        public float Lifetime;
        public float Speed;
        public float FireRate;

        public void Validate()
        {
            if (Lifetime <= 0)
                throw new Exception("Bullet Lifetime must be > 0");

            if (Speed <= 0)
                throw new Exception("Bullet Speed must be > 0");

            if (FireRate <= 0)
                throw new Exception("Bullet FireRate must be > 0");
        }
    }
}