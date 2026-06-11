using System;
using Code.Core.Signals;
using Code.Infrastructure.SceneNameConstants;
using Code.Infrastructure.States;
using Zenject;

namespace Code.Infrastructure.Services.LoadGameLevel
{
    public class LoadGameLevelService : IInitializable, IDisposable, ILoadGameLevelService
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SignalBus _signalBus;

        public LoadGameLevelService(GameStateMachine gameStateMachine, SignalBus signalBus)
        {
            _gameStateMachine = gameStateMachine;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<RestartGameSignal>(OnGameRestarted);
            _signalBus.Subscribe<StartGameSignal>(OnGameRestarted);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<RestartGameSignal>(OnGameRestarted);
            _signalBus.Unsubscribe<StartGameSignal>(OnGameRestarted);
        }

        private async void OnGameRestarted() 
            => await _gameStateMachine.Enter<LoadLevelState, string>(SceneNames.Main);
    }
}