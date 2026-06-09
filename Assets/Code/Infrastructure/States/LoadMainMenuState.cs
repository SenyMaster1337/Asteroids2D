using Code.Core.LoadingCurtains;
using Code.Infrastructure.SceneLoaders;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.States
{
    public class LoadMainMenuState : IPayloadedState<string>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly ILoadingCurtainProvider _loadingCurtainProvider;

        public LoadMainMenuState(SceneLoader sceneLoader, ILoadingCurtainProvider loadingCurtainProvider)
        {
            _sceneLoader = sceneLoader;
            _loadingCurtainProvider = loadingCurtainProvider;
        }

        public async UniTask Enter(string sceneName)
        {
            _loadingCurtainProvider.LoadingCurtain.Hide();
            await _sceneLoader.LoadScene(sceneName);
        }

        public void Exit()
        {
        }
    }
}