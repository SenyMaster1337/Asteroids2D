using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Code.Core.LoadingCurtains
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        private const float FadeInDurationValue = 0.03f;

        private ILoadingCurtainProvider _loadingCurtainProvider;
        private CancellationTokenSource _fadeCts;

        [Inject]
        private void Construct(ILoadingCurtainProvider loadingCurtainProvider)
        {
            _loadingCurtainProvider = loadingCurtainProvider;
        }

        private void Awake()
        {
            _loadingCurtainProvider.SetLoadingCurtain(this);
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            _fadeCts?.Cancel();
            gameObject.SetActive(true);
            _canvasGroup.alpha = 1;
        }

        public void Hide()
        {
            _fadeCts?.Cancel();
            _fadeCts = new CancellationTokenSource();
            FadeIn(_fadeCts.Token).Forget();
        }

        private async UniTask FadeIn(CancellationToken token)
        {
            while (_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= FadeInDurationValue;
                await UniTask.WaitForSeconds(FadeInDurationValue, cancellationToken: token);
            }

            gameObject.SetActive(false);
            _fadeCts?.Dispose();
            _fadeCts = null;
        }

        private void OnDestroy()
        {
            _fadeCts?.Cancel();
            _fadeCts?.Dispose();
        }
    }
}