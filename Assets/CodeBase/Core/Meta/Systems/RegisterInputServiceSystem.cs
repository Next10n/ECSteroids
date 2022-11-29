using Entitas;
using Infrastructure.Services.Input;

namespace Core.Meta.Systems
{
    public class RegisterInputServiceSystem : IInitializeSystem
    {
        private readonly MetaContext _context;
        private readonly IInputService _inputService;

        public RegisterInputServiceSystem(Contexts contexts, IInputService inputService)
        {
            _inputService = inputService;
            _context = contexts.meta;
        }

        public void Initialize()
        {
            _context.ReplaceInputService(_inputService);
        }
    }
}