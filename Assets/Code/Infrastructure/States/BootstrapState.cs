using Code.Infrastructure.SceneLoaders;
using Code.Infrastructure.SceneNameConstants;
using Code.Infrastructure.Services.Analytics;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IFirebaseInitializeService _firebaseInitializeService;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader,
            IFirebaseInitializeService firebaseInitializeService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _firebaseInitializeService = firebaseInitializeService;
        }

        public async UniTask Enter()
        {
            if (SceneManager.GetActiveScene().name == SceneNames.Initial)
            {
                EnterLoadLevel();
            }
            else
            {
                await _sceneLoader.LoadScene(SceneNames.Initial, onLoaded: EnterLoadLevel);
            }
        }

        private async void EnterLoadLevel()
        {
            await _firebaseInitializeService.InitializeAsync();
            await _gameStateMachine.Enter<LoadMainMenuState, string>(SceneNames.Menu);
        }

        public void Exit()
        {
        }
    }
}