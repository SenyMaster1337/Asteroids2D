using Code.Core.Interfaces.Input;
using Code.Infrastructure.Services.LevelReset;

namespace Code.Infrastructure.Services.PlayerInput
{
    public abstract class InputService : IInputService, IInputLocker, ILevelReset
    {
        private bool _isLocked;

        public void Lock()
            => _isLocked = true;

        public void Unlock()
            => _isLocked = false;

        public void Reset()
            => Unlock();

        public float Forward => _isLocked ? 0f : GetForward();
        public float Rotation => _isLocked ? 0f : GetRotation();
        public bool IsOrdinaryAttack => _isLocked == false && GetOrdinaryAttack();
        public bool IsLaserAttack => _isLocked == false && GetLaserAttack();

        protected abstract float GetForward();
        protected abstract float GetRotation();
        protected abstract bool GetOrdinaryAttack();
        protected abstract bool GetLaserAttack();
    }
}