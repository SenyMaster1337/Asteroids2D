using Code.Core.LoadingCurtains;
using Code.Infrastructure.SceneLoaders;
using Code.Infrastructure.SceneNameConstants;
using Code.Infrastructure.Services.LevelEntryProcessors;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly ILoadingCurtainProvider _loadingCurtainProvider;
        private readonly ILevelEntryProcessor _levelEntryProcessor;

        public LoadLevelState(SceneLoader sceneLoader, ILoadingCurtainProvider loadingCurtainProvider,
            ILevelEntryProcessor levelEntryProcessor)
        {
            _sceneLoader = sceneLoader;
            _loadingCurtainProvider = loadingCurtainProvider;
            _levelEntryProcessor = levelEntryProcessor;
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
            _levelEntryProcessor.ProcessEntry();
            _loadingCurtainProvider.LoadingCurtain.Hide();
        }
    }
}