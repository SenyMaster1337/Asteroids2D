using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure.SceneLoaders
{
    public class SceneLoader
    {
        public async UniTask LoadScene(string name, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == name)
            {
                onLoaded?.Invoke();
                return;
            }

            await SceneManager.LoadSceneAsync(name).ToUniTask();

            onLoaded?.Invoke();
        }
    }
}