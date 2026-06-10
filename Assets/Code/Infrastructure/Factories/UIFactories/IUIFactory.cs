using UnityEngine;

namespace Code.Infrastructure.Factories.UIFactories
{
    public interface IUIFactory
    {
        GameObject CreateUIRoot();
        GameObject CreateStartView();
        GameObject CreateHud();
        GameObject CreateRestartView();
        GameObject CreateControlsInstruction();
        GameObject CreatePlayerHealthView();
        GameObject CreateMobileInput();
    }
}