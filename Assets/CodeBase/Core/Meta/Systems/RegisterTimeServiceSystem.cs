using Entitas;
using Infrastructure.Services.Time;

namespace Core.Meta.Systems
{
    public class RegisterTimeServiceSystem : IInitializeSystem
    {
        private readonly MetaContext _context;
        private readonly ITimeService _timeService;

        public RegisterTimeServiceSystem(Contexts contexts, ITimeService timeService)
        {
            _timeService = timeService;
            _context = contexts.meta;
        }

        public void Initialize()
        {
            _context.ReplaceTimeService(_timeService);
        }
    }
}