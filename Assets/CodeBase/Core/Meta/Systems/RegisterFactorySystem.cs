using Core.Factories;
using Entitas;

namespace Core.Meta.Systems
{
    public class RegisterFactorySystem : IInitializeSystem
    {
        private readonly MetaContext _context;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IBulletFactory _bulletFactory;

        public RegisterFactorySystem(Contexts contexts, IEnemyFactory enemyFactory, IBulletFactory bulletFactory)
        {
            _enemyFactory = enemyFactory;
            _bulletFactory = bulletFactory;
            _context = contexts.meta;
        }

        public void Initialize()
        {
            _context.ReplaceEnemyFactory(_enemyFactory);
            _context.ReplaceBulletFactory(_bulletFactory);
        }
    }
}