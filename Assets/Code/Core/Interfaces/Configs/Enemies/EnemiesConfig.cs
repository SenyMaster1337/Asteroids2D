using Code.Infrastructure.Services.ConfigLoaders.Enemies.AlienShip;
using Code.Infrastructure.Services.ConfigLoaders.Enemies.Asteroid;
using Code.Infrastructure.Services.ConfigLoaders.Enemies.AsteroidDebris;

namespace Code.Infrastructure.Services.ConfigLoaders.Enemies
{
    public class EnemiesConfig
    {
        public AsteroidConfig Asteroid;
        public AsteroidDebrisConfig AsteroidDebris;
        public AlienShipConfig AlienShip;
    }
}