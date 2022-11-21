using System.Collections.Generic;
using Entitas;
using Extensions;
using UnityEngine;

namespace Game.Systems
{
    public class TeleportSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private Bounds _orthographicBounds;
        
        public void Initialize()
        {
            _orthographicBounds = Camera.main.OrthographicBounds();
        }

        public TeleportSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Position);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isTeleportable;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity e in entities)
            {
                float x = CalculateTeleportValue(e.position.Value.x, _orthographicBounds.extents.x);
                float y = CalculateTeleportValue(e.position.Value.y, _orthographicBounds.extents.y);
                e.ReplacePosition(new Vector2(x, y));
            }
        }
        
        private float CalculateTeleportValue(float value, float bounds)
        {
            if (value > bounds)
                return -bounds;
            if (value < -bounds)
                return bounds;
            return value;
        }
    }
}