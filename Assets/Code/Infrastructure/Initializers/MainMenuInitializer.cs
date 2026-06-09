using Code.Infrastructure.Factory.UI;
using Zenject;

namespace Code.Infrastructure.Initializers
{
    public class MainMenuInitializer : IInitializable
    {
        private readonly IUIFactory _uiFactory;

        public MainMenuInitializer(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void Initialize()
        {
            _uiFactory.CreateUIRoot();
            _uiFactory.CreateStartView();
        }
    }
}