namespace Code.Core.Interfaces.Input.InputLock
{
    public interface IInputLockService
    {
        bool IsLocked { get; }
        void Lock();
        void Unlock();
    }
}