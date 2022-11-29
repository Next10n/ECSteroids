using System.Collections.Generic;
using Entitas;
using Services.View;

namespace Game.Systems
{
    public class CreateAssetViewSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private readonly Contexts _contexts;
        private IViewService _viewService;

        public CreateAssetViewSystem(IContext<GameEntity> gameContext, Contexts contexts) : base(gameContext)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            _viewService = _contexts.meta.viewService.Value;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Asset);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasAsset;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity viewEntity in entities)
                _viewService.CreateView(_contexts, viewEntity, viewEntity.asset.Value);
        }
    }
}
