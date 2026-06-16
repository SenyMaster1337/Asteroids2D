using System;
using Code.Infrastructure.SceneLoaders;
using Code.Infrastructure.SceneNameConstants;
using Code.Infrastructure.Services.Analytics;
using Cysharp.Threading.Tasks;
using UnityEngine;
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
            if (SceneManager.GetActiveScene().name != SceneNames.Initial)
                await _sceneLoader.LoadScene(SceneNames.Initial);

            try
            {
                await _firebaseInitializeService.InitializeAsync();
            }
            catch (Exception exception)
            {
                Debug.LogError($"Critical: Firebase failed to initialize. {exception.Message}");
            }

            await _gameStateMachine.Enter<LoadMainMenuState, string>(SceneNames.Menu);
        }

        public void Exit()
        {
        }
    }
}