using Code.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.GameBootstrappers
{
    public class GameBootstrapper : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Start()
        {
            EnterBootstrapState();

            DontDestroyOnLoad(this);
        }

        private async void EnterBootstrapState() 
            => await _gameStateMachine.Enter<BootstrapState>();
    }
}