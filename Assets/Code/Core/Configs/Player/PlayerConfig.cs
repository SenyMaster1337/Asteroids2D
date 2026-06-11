using Code.Core.ConfigLoaders;

namespace Code.Infrastructure.Services.ConfigLoaders.Player
{
    public class PlayerConfig
    {
        public PhysicsConfig Physics;
        public PlayerMoverConfig Mover;
        public PlayerHealthConfig Health;
        public BulletConfig Bullet;
        public LaserConfig Laser;
        public PlayerInvincibilityConfig Invincibility;
    }
}