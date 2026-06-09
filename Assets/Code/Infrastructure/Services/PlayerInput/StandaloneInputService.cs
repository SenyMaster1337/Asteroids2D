using UnityEngine;

namespace Code.Infrastructure.Services.PlayerInput
{
    public class StandaloneInputService : InputService
    {
        private const KeyCode ForwardKey = KeyCode.W;
        private const KeyCode RotateLeftKey = KeyCode.A;
        private const KeyCode RotateRightKey = KeyCode.D;

        protected override float GetForward() =>
            Input.GetKey(ForwardKey) ? 1f : 0f;

        protected override float GetRotation()
        {
            if (Input.GetKey(RotateLeftKey))
                return -1f;

            if (Input.GetKey(RotateRightKey))
                return 1f;

            return 0f;
        }

        protected override bool GetOrdinaryAttack() =>
            Input.GetMouseButtonDown(0);

        protected override bool GetLaserAttack() =>
            Input.GetMouseButtonDown(1);
    }
}