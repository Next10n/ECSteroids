using Entitas;
using Game.Factories;

namespace Services.Systems
{
    public class RegisterFactorySystem : IInitializeSystem
    {
        private readonly MetaContext _context;
        private readonly IEnemyFactory _enemyFactory;

        public RegisterFactorySystem(Contexts contexts, IEnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
            _context = contexts.meta;
        }

        public void Initialize()
        {
            _context.ReplaceEnemyFactory(_enemyFactory);
        }
    }
}