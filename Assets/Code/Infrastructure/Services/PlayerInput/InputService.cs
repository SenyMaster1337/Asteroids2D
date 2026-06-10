using Code.Core.Interfaces.Input;
using Code.Core.Interfaces.Input.InputLock;
using Code.Infrastructure.Services.LevelReset;
using Code.Infrastructure.Services.PlayerInput.InputLockServices;

namespace Code.Infrastructure.Services.PlayerInput
{
    public abstract class InputService : IInputService
    {
        private readonly IInputLockService _inputLockService;

        protected InputService(IInputLockService inputLockService)
        {
            _inputLockService = inputLockService;
        }

        public float Forward => _inputLockService.IsLocked ? 0f : GetForward();
        public float Rotation => _inputLockService.IsLocked ? 0f : GetRotation();
        public bool IsOrdinaryAttack => _inputLockService.IsLocked == false && GetOrdinaryAttack();
        public bool IsLaserAttack => _inputLockService.IsLocked == false && GetLaserAttack();

        protected abstract float GetForward();
        protected abstract float GetRotation();
        protected abstract bool GetOrdinaryAttack();
        protected abstract bool GetLaserAttack();
    }
}