using System;

namespace Code.Core.Configs.Area
{
    public class AreaConfig : IConfigValidate
    {
        public float WorldWidth;
        public float WorldHeight;
        public int MaxEnemies;

        public void Validate()
        {
            if (WorldWidth <= 0)
                throw new Exception("WorldWidth must be > 0");

            if (WorldHeight <= 0)
                throw new Exception("WorldHeight must be > 0");

            if (MaxEnemies <= 0)
                throw new Exception("MaxEnemies must be > 0");
        }
    }
}