using System;

namespace Code.Core.Configs.Enemies.AlienShip
{
    public class AlienShipFollowerConfig : IConfigValidate
    {
        public float Speed;
        public float Agility;
        
        public void Validate()
        {
            if (Speed < 0)
                throw new Exception("AlienShip Speed must be >= 0");
            
            if (Agility < 0) 
                throw new Exception("AlienShip Agility must be >= 0");
        }
    }
}