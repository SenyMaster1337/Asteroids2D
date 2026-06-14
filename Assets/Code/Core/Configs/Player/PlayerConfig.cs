namespace Code.Core.Configs.Player
{
    public class PlayerConfig : IConfigValidate
    {
        public PhysicsConfig Physics;
        public PlayerMoverConfig Mover;
        public PlayerHealthConfig Health;
        public BulletConfig Bullet;
        public LaserConfig Laser;
        public PlayerInvincibilityConfig Invincibility;
        
        public void Validate()
        {
            Health.Validate();
            Mover.Validate();
            Bullet.Validate();
            Laser.Validate();
            Invincibility.Validate();
            Physics.Validate();
        }
    }
}