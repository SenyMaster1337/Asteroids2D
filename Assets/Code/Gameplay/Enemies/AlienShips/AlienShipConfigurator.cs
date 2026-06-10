using Code.Gameplay.Physics;
using Code.Infrastructure.Services.ConfigLoaders.Enemies;
using UnityEngine;

namespace Code.Gameplay.Enemies.AlienShips
{
    public class AlienShipConfigurator : MonoBehaviour, IEnemyConfigurator
    {
        public void Configure(EnemiesConfig config)
        {
            var alienShipConfig = config.AlienShip;
            GetComponent<AlienShipFollower>().Init(alienShipConfig.Follower.Speed, alienShipConfig.Follower.Agility);
            GetComponent<PhysicsBody2D>().Init(alienShipConfig.Physics.Mass);
            GetComponent<KnockbackToCollision>().Init(alienShipConfig.Physics.KnockbackForce);
        }
    }
}