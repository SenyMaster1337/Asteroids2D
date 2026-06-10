using UnityEngine;

namespace Code.Infrastructure.Factories.ProjectileFactories
{
    public interface IProjectileFactory
    {
        GameObject CreateBullet();
        GameObject CreateLaser();
    }
}