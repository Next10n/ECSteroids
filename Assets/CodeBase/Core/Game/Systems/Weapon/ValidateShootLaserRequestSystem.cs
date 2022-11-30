using System.Collections.Generic;
using Core.Factories;
using Core.Game.Components;
using Entitas;
using UnityEngine;

namespace Core.Game.Systems.Weapon
{
    public class ValidateShootLaserRequestSystem : ReactiveSystem<GameEntity>
    {
        public ValidateShootLaserRequestSystem(Contexts contexts) : base(contexts.game)
        {
        }
        
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ShootRequest);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isLaserWeapon && entity.hasLaserStorage;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(GameEntity entity in entities) 
                entity.isShootRequest = entity.laserStorage.Value > 0;
        }
    }
}