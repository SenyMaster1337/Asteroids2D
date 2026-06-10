using Code.Core.ConfigLoaders;
using Code.Core.LoadingCurtains;
using Code.Core.Signals;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.GoogleAds;
using Code.Infrastructure.SceneLoaders;
using Code.Infrastructure.Services.Analytics;
using Code.Infrastructure.Services.ConfigServices;
using Code.Infrastructure.Services.GoogleAdsShowers;
using Code.Infrastructure.Services.PlayerInput;
using Code.Infrastructure.Services.PlayerInput.InputLockServices;
using Code.Infrastructure.Services.PlayerInput.Standalone;
using Code.Infrastructure.Services.StaticData;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Factory;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInputs();
            BindProviders();
            BindStates();
            BindSceneLoader();
            BindServices();
            BindSignals();
            BindGoogleAds();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<ConfigService>().AsSingle();
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle();
            Container.BindInterfacesAndSelfTo<FirebaseInitializeService>().AsSingle();
            Container.Bind<IConfigLoader>().To<JsonConfigLoader>().AsSingle();

#if UNITY_ANDROID || UNITY_IOS
            Container.Bind<IVirtualJoystickProvider>().To<VirtualJoystickProvider>().AsSingle();
#endif
        }

        private void BindStates()
        {
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
            Container.Bind<GameStateMachine>().AsSingle();
            Container.Bind<BootstrapState>().AsSingle();
            Container.Bind<LoadMainMenuState>().AsSingle();
            Container.Bind<LoadLevelState>().AsSingle();
        }

        private void BindProviders()
        {
            Container.Bind<ILoadingCurtainProvider>().To<LoadingCurtainProvider>().AsSingle();
        }

        private void BindInputs()
        {
#if UNITY_ANDROID || UNITY_IOS
            Container.BindInterfacesAndSelfTo<MobileInputService>().AsSingle();
#else
            Container.BindInterfacesAndSelfTo<StandaloneInputService>().AsSingle();
#endif
            
            Container.BindInterfacesAndSelfTo<InputLockService>().AsSingle();
        }

        private void BindSceneLoader()
        {
            Container.Bind<SceneLoader>().AsSingle();
        }

        private void BindSignals()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<StartGameSignal>();
            Container.DeclareSignal<RestartGameSignal>();
        }

        private void BindGoogleAds()
        {
            Container.BindInterfacesAndSelfTo<InterAd>().AsSingle();
            Container.BindInterfacesAndSelfTo<GoogleAdsShowerService>().AsSingle();
        }
    }
}