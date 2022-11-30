using System.Collections.Generic;
using Entitas;
using Infrastructure.Services.Pool;

namespace Core.Game.Systems.View
{
    public class GetPoolViewSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private readonly Contexts _contexts;
        private IPoolService _poolService;

        public GetPoolViewSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            _poolService = _contexts.meta.poolService.Value;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.PoolObject);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(GameEntity e in entities)
            {
                _poolService.InjectPoolView(e, e.poolObject.Value);
            }
        }
    }
}