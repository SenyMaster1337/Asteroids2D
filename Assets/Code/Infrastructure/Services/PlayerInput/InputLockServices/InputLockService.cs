using Code.Core.Interfaces.Input.InputLock;
using Code.Infrastructure.Services.LevelReset;

namespace Code.Infrastructure.Services.PlayerInput.InputLockServices
{
    public class InputLockService : IInputLockService, ILevelReset
    {
        private bool _isLocked;

        public bool IsLocked => _isLocked;

        public void Lock()
            => _isLocked = true;

        public void Unlock()
            => _isLocked = false;

        public void Reset()
            => Unlock();
    }
}