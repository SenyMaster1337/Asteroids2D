namespace Code.Gameplay.Area
{
    public class GameAreaProvider : IGameAreaProvider
    {
        public GameArea GameArea { get; private set; }

        public void SetGameArea(GameArea gameArea)
        {
            GameArea = gameArea;
        }
    }
}