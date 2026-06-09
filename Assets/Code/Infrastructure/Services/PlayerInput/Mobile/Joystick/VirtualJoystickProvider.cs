namespace Code.Infrastructure.Services.PlayerInput.Mobile.Joystick
{
    public class VirtualJoystickProvider : IVirtualJoystickProvider
    {
        public VirtualJoystick Joystick { get; private set; }

        public void SetJoystick(VirtualJoystick joystick) =>
            Joystick = joystick;
    }
}