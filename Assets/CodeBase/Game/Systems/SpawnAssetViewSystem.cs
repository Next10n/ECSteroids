using System.Collections.Generic;
using Entitas;
using Services.AssetProvider;
using Services.View;

namespace Views.Systems
{
    public class SpawnAssetViewSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private readonly Contexts _contexts;
        private IViewService _viewService;

        public SpawnAssetViewSystem(IContext<GameEntity> gameContext, Contexts contexts) : base(gameContext)
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
            return entity.hasAsset && entity.hasPositionListener == false;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity viewEntity in entities)
                _viewService.CreateView(_contexts, viewEntity, viewEntity.asset.Value);
        }
    }
}
