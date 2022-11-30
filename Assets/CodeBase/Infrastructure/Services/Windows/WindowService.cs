using View.UI;

namespace Infrastructure.Services.Windows
{
    public class WindowService : IWindowService
    {
        private ResultWindow _resultWindow;
        private PlayerHud _hud;
        
        private readonly IWindowFactory _windowFactory;

        public WindowService(IWindowFactory windowFactory)
        {
            _windowFactory = windowFactory;
        }

        public void ShowHud()
        {
            if(_hud == null)
                _hud = _windowFactory.CreateHud();
        }

        public void InitializeHud(Contexts contexts, GameEntity player)
        {
            _hud.Initialize(contexts, player);
        }

        public void ShowResult()
        {
            if (_resultWindow == null)
                _resultWindow = _windowFactory.CreateResultWindow();
            else
                _resultWindow.gameObject.SetActive(true);
        }

        public void HideResult() => 
            _resultWindow.gameObject.SetActive(false);
    }
}