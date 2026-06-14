using System;
using Firebase;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Infrastructure.Services.Analytics
{
    public class FirebaseInitializeService : IFirebaseInitializeService
    {
        public async UniTask InitializeAsync()
        {
            try
            {
                var firebaseTask = FirebaseApp.CheckAndFixDependenciesAsync();
                await firebaseTask;

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