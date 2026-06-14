using Code.Core.LoadingCurtains;
using Code.Infrastructure.Events;
using Code.Infrastructure.SceneLoaders;
using Code.Infrastructure.SceneNameConstants;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly ILoadingCurtainProvider _loadingCurtainProvider;
        private readonly LevelEntryEvent _levelEntryEvent;

        public LoadLevelState(SceneLoader sceneLoader, ILoadingCurtainProvider loadingCurtainProvider,
            LevelEntryEvent levelEntryEvent)
        {
            _sceneLoader = sceneLoader;
            _loadingCurtainProvider = loadingCurtainProvider;
            _levelEntryEvent = levelEntryEvent;
        }

        public async UniTask Enter(string sceneName)
        {
            _loadingCurtainProvider.LoadingCurtain.Show();
            await _sceneLoader.LoadScene(SceneNames.Empty);
            await _sceneLoader.LoadScene(sceneName, OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            _levelEntryEvent.Notify();
            _loadingCurtainProvider.LoadingCurtain.Hide();
        }
    }
}