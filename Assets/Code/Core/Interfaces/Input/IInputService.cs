namespace Code.Core.Interfaces.Input
{
    public interface IInputService
    {
        float Forward { get; }
        float Rotation { get; }
        bool IsOrdinaryAttack { get; }
        bool IsLaserAttack { get; }
    }
}