using Entitas;
using Infrastructure.Services.View;

namespace Core.Meta.Systems
{
    public class RegisterViewServiceSystem : IInitializeSystem
    {
        private readonly MetaContext _context;
        private readonly IViewService _viewService;

        public RegisterViewServiceSystem(Contexts contexts, IViewService viewService)
        {
            _viewService = viewService;
            _context = contexts.meta;
        }

        public void Initialize()
        {
            _context.ReplaceViewService(_viewService);
        }
    }
}