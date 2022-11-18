using System.Collections.Generic;
using Entitas;
using Services.AssetProvider;
using Services.View;

namespace Views.Systems
{
    public class SpawnAssetViewSystem : ReactiveSystem<ViewEntity>, IInitializeSystem
    {
        private readonly Contexts _contexts;
        private IViewService _viewService;

        public SpawnAssetViewSystem(IContext<ViewEntity> viewContext, Contexts contexts) : base(viewContext)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            _viewService = _contexts.meta.viewService.Value;
        }

        protected override ICollector<ViewEntity> GetTrigger(IContext<ViewEntity> context)
        {
            return context.CreateCollector(ViewMatcher.Asset);
        }

        protected override bool Filter(ViewEntity entity)
        {
            return entity.hasAsset && entity.hasView == false;
        }

        protected override void Execute(List<ViewEntity> entities)
        {
            foreach (ViewEntity viewEntity in entities)
            {
                IViewController view = _viewService.CreateView(_contexts, viewEntity, viewEntity.asset.Value);
                viewEntity.AddView(view);
            }
        }
    }
}
