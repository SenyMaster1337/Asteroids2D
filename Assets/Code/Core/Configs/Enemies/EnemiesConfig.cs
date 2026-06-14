using Code.Core.Configs.Enemies.AlienShip;
using Code.Core.Configs.Enemies.Asteroid;
using Code.Core.Configs.Enemies.AsteroidDebris;

namespace Code.Core.Configs.Enemies
{
    public class EnemiesConfig : IConfigValidate
    {
        public AsteroidConfig Asteroid;
        public AsteroidDebrisConfig AsteroidDebris;
        public AlienShipConfig AlienShip;

        public void Validate()
        {
            Asteroid.Validate();
            AsteroidDebris.Validate();
            AlienShip.Validate();
        }
    }
}