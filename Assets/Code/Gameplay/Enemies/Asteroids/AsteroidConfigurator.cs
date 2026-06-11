using Code.Core.Configs.Enemies;
using Code.Gameplay.Physics;
using UnityEngine;

namespace Code.Gameplay.Enemies.Asteroids
{
    public class AsteroidConfigurator : MonoBehaviour, IEnemyConfigurator
    {
        public void Configure(EnemiesConfig config)
        {
            var asteroidConfig = config.Asteroid;
            GetComponent<Asteroid>().Init(asteroidConfig.AsteroidDebrisCount);
            GetComponent<AsteroidMover>().Init(asteroidConfig.Mover.Speed, asteroidConfig.Mover.RotationSpeed);
            GetComponent<PhysicsBody2D>().Init(asteroidConfig.Physics.Mass);
            GetComponent<KnockbackToCollision>().Init(asteroidConfig.Physics.KnockbackForce);
        }
    }
}