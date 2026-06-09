namespace Code.Infrastructure.Services.PlayerInput.Mobile.Joystick
{
    public interface IVirtualJoystickProvider
    {
        VirtualJoystick Joystick { get; }
        void SetJoystick(VirtualJoystick joystick);
    }
}