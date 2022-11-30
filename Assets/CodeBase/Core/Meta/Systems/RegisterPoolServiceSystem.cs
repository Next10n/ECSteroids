using Entitas;
using Infrastructure.Services.Pool;

namespace Core.Meta.Systems
{
    public class RegisterPoolServiceSystem : IInitializeSystem
    {
        private readonly MetaContext _context;
        private readonly IPoolService _poolService;

        public RegisterPoolServiceSystem(Contexts contexts, IPoolService poolService)
        {
            _poolService = poolService;
            _context = contexts.meta;
        }

        public void Initialize()
        {
            _context.ReplacePoolService(_poolService);
        }
    }
}