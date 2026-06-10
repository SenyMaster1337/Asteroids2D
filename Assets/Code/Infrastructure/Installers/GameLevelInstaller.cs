using Code.Core.CameraProviders;
using Code.Gameplay.Area;
using Code.Gameplay.PlayerProviders;
using Code.Infrastructure.Factories.AreaFactories;
using Code.Infrastructure.Factories.EnemyFactories;
using Code.Infrastructure.Factories.PlayerFactories;
using Code.Infrastructure.Factories.ProjectileFactories;
using Code.Infrastructure.Factories.UIFactories;
using Code.Infrastructure.Initializers;
using Code.Infrastructure.Services.EnemyWave;
using Code.Infrastructure.Services.LevelReset;
using Code.Infrastructure.Services.LoadGameLevel;
using Code.Infrastructure.Services.LoseServices;
using Code.Infrastructure.Services.PlayerTeleports;
using Code.Infrastructure.Services.Reward;
using Code.Infrastructure.Services.ScoreService;
using Code.Infrastructure.Services.Spawners.Enemies;
using Code.Infrastructure.Services.Spawners.Projectile;
using Code.UI.Binders;
using Code.UI.ViewModels;
using MVVM;
using Zenject;
using EnemyDeathHandler = Code.Infrastructure.Services.EnemyDeathHandlers.EnemyDeathHandler;

namespace Code.Infrastructure.Installers
{
    public class GameLevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFactories();
            BindServices();
            BindInitializers();
            BindBinders();
            BindViewModels();
        }

        private void BindFactories()
        {
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
            Container.Bind<IGameAreaFactory>().To<GameAreaFactory>().AsSingle();
            Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle();
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
            Container.Bind<IProjectileFactory>().To<ProjectileFactory>().AsSingle();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<BulletSpawnerService>().AsSingle();
            Container.Bind<IPlayerProvider>().To<PlayerProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<LaserSpawnersService>().AsSingle();
            Container.Bind<IGameAreaProvider>().To<GameAreaProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerTeleportToAreaService>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemySpawnerService>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyWaveService>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoseService>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadGameLevelService>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelResetService>().AsSingle();
            Container.Bind<ICameraProvider>().To<CameraProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<ScoreService>().AsSingle();
            Container.BindInterfacesAndSelfTo<RewardService>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyDeathHandler>().AsSingle();
        }

        private void BindInitializers()
        {
            Container.Bind<IInitializable>().To<GameLevelInitializer>().AsSingle();
        }

        private void BindBinders()
        {
            BinderFactory.RegisterBinder<TextBinder>();
            BinderFactory.RegisterBinder<GameObjectDisableListBinder>();
            BinderFactory.RegisterBinder<ButtonBinder>();
        }

        private void BindViewModels()
        {
            Container.BindInterfacesAndSelfTo<PlayerCoordinatesViewModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<LaserChargesViewModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<LaserCooldownViewModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<RotationAngleViewModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerVelocityViewModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<HealthViewModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<RestartViewModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<ScoreViewModel>().AsSingle();

#if UNITY_ANDROID || UNITY_IOS
            Container.BindInterfacesAndSelfTo<DefaultAttackViewModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<LaserAttackViewModel>().AsSingle();
#endif
        }
    }
}