using Code.Core.BaseEnemies;

namespace Code.Gameplay.Enemies.Asteroids
{
    public class AsteroidDebris : BaseEnemy
    {
        private AsteroidMover _asteroidMover;

        protected override void OnAwake()
        {
            base.OnAwake();
            _asteroidMover = GetComponent<AsteroidMover>();
        }

        public override void Launch()
            => _asteroidMover.Launch(true);
        
        public override void Die()
        {
            if (TryMarkDead() == false) 
                return;

            base.Die();
        }

        public override void Reset()
        {
            base.Reset();
            _asteroidMover.ResetVelocity();
        }
    }
}