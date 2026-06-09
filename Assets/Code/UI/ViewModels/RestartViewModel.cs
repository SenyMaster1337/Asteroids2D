using System;
using Code.Core.Signals;
using MVVM;
using Zenject;

namespace Code.UI.ViewModels
{
    public class RestartViewModel
    {
        [Data("RestartGame")]
        public readonly Action RestartGame;

        private readonly SignalBus _signalBus;

        public RestartViewModel(SignalBus signalBus)
        {
            _signalBus = signalBus;
            RestartGame = OnRestartGame;
        }

        private void OnRestartGame() =>
            _signalBus.Fire<RestartGameSignal>();
    }
}