using System;

namespace Code.Core.Configs.Player
{
    public class PhysicsConfig : IConfigValidate
    {
        public float Mass;
        public float KnockbackForce;

        public void Validate()
        {
            if (Mass <= 0)
                throw new Exception("Physics Mass must be > 0");

            if (KnockbackForce < 0)
                throw new Exception("Physics KnockbackForce must be >= 0");
        }
    }
}