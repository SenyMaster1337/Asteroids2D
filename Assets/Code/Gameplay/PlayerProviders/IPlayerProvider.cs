using Code.Gameplay.Players;

namespace Code.Gameplay.PlayerProviders
{
    public interface IPlayerProvider
    {
        Player Player { get; }
        void SetPlayer(Player player);
    }
}