using Entitas;
using Services.Windows;

namespace Services.Systems
{
    public class RegisterWindowServiceSystem : IInitializeSystem
    {
        private readonly MetaContext _context;
        private readonly IWindowService _windowService;

        public RegisterWindowServiceSystem(Contexts contexts, IWindowService windowService)
        {
            _windowService = windowService;
            _context = contexts.meta;
        }

        public void Initialize()
        {
            _context.ReplaceWindowService(_windowService);
        }
    }
}