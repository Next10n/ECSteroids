using System.Collections.Generic;
using Entitas;

namespace Views.Systems
{
    // public class ViewPositionSystem : ReactiveSystem<GameEntity>
    // {
    //     public ViewPositionSystem(Contexts contexts) : base(contexts.game)
    //     {
    //     }
    //
    //     protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    //     {
    //         return context.CreateCollector(GameMatcher.Position);
    //     }
    //
    //     protected override bool Filter(GameEntity entity)
    //     {
    //         return entity.hasView && entity.hasPosition;
    //     }
    //
    //     protected override void Execute(List<GameEntity> entities)
    //     {
    //         foreach (GameEntity e in entities)
    //         {
    //             e.view.Value.Position = e.position.Value;
    //         }
    //     }
    // }
}