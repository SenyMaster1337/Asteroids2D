using System;
using System.Threading;
using Firebase;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Services.Analytics
{
    public class FirebaseInitializeService : IFirebaseInitializeService, IInitializable, IDisposable
    {
        private CancellationTokenSource _cts;

        public void Initialize()
        {
            _cts = new CancellationTokenSource();
            InitializeAsync(_cts.Token).Forget();
        }

        public void Dispose()
        {
            _cts?.Cancel();
            _cts?.Dispose();
        }

        private async UniTask InitializeAsync(CancellationToken token)
        {
            try
            {
                var firebaseTask = FirebaseApp.CheckAndFixDependenciesAsync();

                await firebaseTask;

                token.ThrowIfCancellationRequested();

                if (firebaseTask.Result == DependencyStatus.Available)
                {
                    Firebase.Analytics.FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
                    LogGameStarted();
                }
                else
                {
                    throw new Exception("Firebase dependencies are not available: " + firebaseTask.Result);
                }
            }
            catch (OperationCanceledException)
            {
                Debug.LogWarning("Firebase initialization was canceled.");
            }
            catch (Exception exception)
            {
                Debug.LogError($"Firebase initialization failed: {exception.Message}");
            }
        }

        private void LogGameStarted()
            => Firebase.Analytics.FirebaseAnalytics.LogEvent("game_started");
    }
}