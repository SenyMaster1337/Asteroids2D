using UnityEngine;

namespace Code.Infrastructure.Factory.UI
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