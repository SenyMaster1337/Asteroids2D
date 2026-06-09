namespace Code.Core.Interfaces.Input
{
    public interface IInputLocker
    {
        void Lock();
        void Unlock();
    }
}