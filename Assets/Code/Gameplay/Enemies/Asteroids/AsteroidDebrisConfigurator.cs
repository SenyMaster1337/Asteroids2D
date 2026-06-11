using Code.Core.Configs.Enemies;
using Code.Gameplay.Physics;
using UnityEngine;

namespace Code.Gameplay.Enemies.Asteroids
{
    public class AsteroidDebrisConfigurator : MonoBehaviour, IEnemyConfigurator
    {
        public void Configure(EnemiesConfig config)
        {
            var asteroidDebrisConfig = config.AsteroidDebris;
            GetComponent<AsteroidMover>().Init(asteroidDebrisConfig.Mover.Speed, asteroidDebrisConfig.Mover.RotationSpeed);
            GetComponent<PhysicsBody2D>().Init(asteroidDebrisConfig.Physics.Mass);
            GetComponent<KnockbackToCollision>().Init(asteroidDebrisConfig.Physics.KnockbackForce);
        }
    }
}