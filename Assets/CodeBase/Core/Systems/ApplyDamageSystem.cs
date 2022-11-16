using Entitas;

namespace Core.Systems
{
    public class ApplyDamageSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;

        public ApplyDamageSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Health, GameMatcher.Damage));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _group)
            {
                float damagedHealth = entity.health.Value - entity.damage.Value; 
                entity.ReplaceHealth(damagedHealth);                    
            }
        }
    }
}