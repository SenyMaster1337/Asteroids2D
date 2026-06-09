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
            InitWithTimeout(_cts.Token).Forget();
        }

        private async UniTaskVoid InitWithTimeout(CancellationToken token)
        {
            var firebaseTask = FirebaseApp.CheckAndFixDependenciesAsync();

            await firebaseTask;

            if (firebaseTask.Result == DependencyStatus.Available)
            {
                Firebase.Analytics.FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
                LogGameStarted();
            }
        }

        private void LogGameStarted()
            => Firebase.Analytics.FirebaseAnalytics.LogEvent("game_started");

        public void Dispose()
        {
            _cts?.Cancel();
            _cts?.Dispose();
        }
    }
}