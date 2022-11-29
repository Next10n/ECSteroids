using Entitas;
using Infrastructure.Services.StaticData;

namespace Core.Meta.Systems
{
    public class RegisterStaticDataServiceSystem : IInitializeSystem
    {
        private readonly MetaContext _context;
        private readonly IStaticDataService _staticDataService;

        public RegisterStaticDataServiceSystem(Contexts contexts, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _context = contexts.meta;
        }

        public void Initialize()
        {
            _context.ReplaceStaticDataService(_staticDataService);
        }
    }
}