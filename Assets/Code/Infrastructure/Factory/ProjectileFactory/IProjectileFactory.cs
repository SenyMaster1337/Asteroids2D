using UnityEngine;

namespace Code.Infrastructure.Factory.ProjectileFactory
{
    public interface IProjectileFactory
    {
        GameObject CreateBullet();
        GameObject CreateLaser();
    }
}