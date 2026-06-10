using Code.Infrastructure.Factories.UIFactories;
using Code.Infrastructure.Initializers;
using Code.Infrastructure.Services.LoadGameLevel;
using Code.UI.Binders;
using Code.UI.ViewModels;
using MVVM;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class MainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFactories();
            BindInitializers();
            BindBinders();
            BindViewModels();
        }

        private void BindFactories()
        {
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadGameLevelService>().AsSingle();
        }

        private void BindInitializers()
        {
            Container.Bind<IInitializable>().To<MainMenuInitializer>().AsSingle();
        }

        private void BindBinders()
        {
            BinderFactory.RegisterBinder<ButtonBinder>();
        }

        private void BindViewModels()
        {
            Container.BindInterfacesAndSelfTo<StartViewModel>().AsSingle().NonLazy();
        }
    }
}