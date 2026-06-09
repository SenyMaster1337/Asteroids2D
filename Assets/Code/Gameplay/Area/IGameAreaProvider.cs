namespace Code.Gameplay.Area
{
    public interface IGameAreaProvider
    {
        GameArea GameArea { get; }
        void SetGameArea(GameArea gameArea);
    }
}