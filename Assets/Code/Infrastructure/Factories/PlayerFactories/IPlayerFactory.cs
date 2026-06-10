using UnityEngine;

namespace Code.Infrastructure.Factories.PlayerFactories
{
    public interface IPlayerFactory
    {
        GameObject CreatePlayer();
    }
}