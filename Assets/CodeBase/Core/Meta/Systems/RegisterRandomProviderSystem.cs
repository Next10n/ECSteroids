using Entitas;
using Infrastructure.Services;

namespace Core.Meta.Systems
{
    public class RegisterRandomProviderSystem : IInitializeSystem
    {
        private readonly MetaContext _context;
        private readonly IRandomProvider _randomProvider;

        public RegisterRandomProviderSystem(Contexts contexts, IRandomProvider randomProvider)
        {
            _randomProvider = randomProvider;
            _context = contexts.meta;
        }

        public void Initialize()
        {
            _context.ReplaceRandomProvider(_randomProvider);
        }
    }
}