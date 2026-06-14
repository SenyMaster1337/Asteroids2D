using System;

namespace Code.Core.Configs.Player
{
    public class PlayerInvincibilityConfig : IConfigValidate
    {
        public float Duration;

        public void Validate()
        {
            if (Duration <= 0)
                throw new Exception("Invincibility Duration must be > 0");
        }
    }
}