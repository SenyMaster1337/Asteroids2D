using System;
using Code.Core.Signals;
using MVVM;
using Zenject;

namespace Code.UI.ViewModels
{
    public class StartViewModel
    {
        [Data("StartGame")]
        public readonly Action StartGame;

        private readonly SignalBus _signalBus;

        public StartViewModel(SignalBus signalBus)
        {
            _signalBus = signalBus;
            StartGame = OnStartGame;
        }

        private void OnStartGame() =>
            _signalBus.Fire<StartGameSignal>();
    }
}