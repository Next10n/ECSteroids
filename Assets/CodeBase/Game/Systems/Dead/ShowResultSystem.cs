using System.Collections.Generic;
using Entitas;
using Services.Windows;

namespace Game.Systems.Dead
{
    public class ShowResultSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private readonly Contexts _contexts;
        private IWindowService _windowService;

        public ShowResultSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            _windowService = _contexts.meta.windowService.Value;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.DestroyEntity);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPlayer;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            if(entities.Count > 0)
                _windowService.ShowResult();
        }
    }
}