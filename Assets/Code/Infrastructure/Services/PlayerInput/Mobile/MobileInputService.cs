using Code.Core.Interfaces.Input;
using Code.Core.Interfaces.Input.InputLock;
using Code.Infrastructure.Services.PlayerInput.Mobile.Joystick;
using UnityEngine;

namespace Code.Infrastructure.Services.PlayerInput.Mobile
{
    public class MobileInputService : InputService, IMobileFireInput
    {
        private readonly IVirtualJoystickProvider _joystickProvider;
        private bool _ordinaryAttack;
        private bool _laserAttack;

        public MobileInputService(IVirtualJoystickProvider joystickProvider, IInputLockService inputLockService) :
            base(inputLockService)
        {
            _joystickProvider = joystickProvider;
        }

        protected override float GetForward() =>
            Mathf.Max(0f, _joystickProvider.Joystick.Vertical);

        protected override float GetRotation() =>
            _joystickProvider.Joystick.Horizontal;

        protected override bool GetOrdinaryAttack()
        {
            bool value = _ordinaryAttack;
            _ordinaryAttack = false;
            return value;
        }

        protected override bool GetLaserAttack()
        {
            bool value = _laserAttack;
            _laserAttack = false;
            return value;
        }

        public void SetOrdinaryAttack()
            => _ordinaryAttack = true;

        public void SetLaserAttack()
            => _laserAttack = true;
    }
}