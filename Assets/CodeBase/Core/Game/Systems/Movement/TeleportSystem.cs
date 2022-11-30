using System.Collections.Generic;
using Entitas;
using Infrastructure.Services;
using UnityEngine;

namespace Core.Game.Systems
{
    public class TeleportSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private readonly Contexts _contexts;
        private ICameraProvider _cameraProvider;

        public TeleportSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            _cameraProvider = _contexts.meta.cameraProvider.Value;
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
            Bounds mainCameraBounds = _cameraProvider.GetMainCameraBounds();
            foreach (GameEntity e in entities)
            {
                float x = CalculateTeleportValue(e.position.Value.x, mainCameraBounds.extents.x);
                float y = CalculateTeleportValue(e.position.Value.y, mainCameraBounds.extents.y);
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