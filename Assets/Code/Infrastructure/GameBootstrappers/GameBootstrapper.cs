using Code.Infrastructure.States;
using Cysharp.Threading.Tasks;
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
            DontDestroyOnLoad(this);
            _gameStateMachine.Enter<BootstrapState>().Forget();
        }
    }
}