using System;

namespace Code.Core.Configs.Player
{
    public class PlayerHealthConfig : IConfigValidate
    {
        public int MaxHealth;

        public void Validate()
        {
            if (MaxHealth <= 0)
                throw new Exception("MaxHealth must be > 0");
        }
    }
}