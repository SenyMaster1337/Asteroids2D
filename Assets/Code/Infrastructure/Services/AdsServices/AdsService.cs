using System;
using Code.Infrastructure.Events;
using GoogleMobileAds.Api;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Services.AdsServices
{
    public class AdsService : IInitializable, IDisposable, IAdsService
    {
        private const string InterstitialUnitId = "ca-app-pub-3940256099942544/1033173712";

        private readonly LevelEntryEvent _levelEntryEvent;

        private InterstitialAd _interstitialAd;

        public AdsService(LevelEntryEvent levelEntryEvent)
        {
            _levelEntryEvent = levelEntryEvent;
        }

        public void Initialize()
        {
            MobileAds.Initialize(initStatus => { });
            LoadAd();

            _levelEntryEvent.OnLevelEntry += ShowInterAd;
        }

        public void Dispose()
        {
            _levelEntryEvent.OnLevelEntry -= ShowInterAd;
        }

        private void ShowInterAd()
        {
            if (_interstitialAd != null && _interstitialAd.CanShowAd())
                _interstitialAd.Show();
        }

        private void LoadAd()
        {
            if (_interstitialAd != null)
            {
                _interstitialAd.Destroy();
            }

            var adRequest = new AdRequest();

            InterstitialAd.Load(InterstitialUnitId, adRequest, (InterstitialAd ad, LoadAdError error) =>
            {
                if (error != null)
                {
                    Debug.LogError($"Interstitial ad failed to load: {error}");
                    return;
                }

                _interstitialAd = ad;
                RegisterEventHandlers();
            });
        }

        private void RegisterEventHandlers()
            => _interstitialAd.OnAdFullScreenContentClosed += () => { LoadAd(); };
    }
}