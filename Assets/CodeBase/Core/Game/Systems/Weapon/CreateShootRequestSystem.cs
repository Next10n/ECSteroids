using Entitas;

namespace Core.Game.Systems.Weapon
{
    public class CreateShootRequestSystem : IExecuteSystem
    {
        private readonly IGroup<InputEntity> _shootInput;
        private readonly IGroup<GameEntity> _weapons;

        public CreateShootRequestSystem(Contexts contexts)
        {
            _shootInput = contexts.input.GetGroup(InputMatcher.ShootInput);
            _weapons = contexts.game.GetGroup(GameMatcher.AnyOf(GameMatcher.BulletWeapon, GameMatcher.LaserWeapon));
        }
        
        public void Execute()
        {
            foreach(InputEntity inputEntity in _shootInput)
            foreach(GameEntity gameEntity in _weapons)
            {
                gameEntity.isShootRequest = true;
            }
        }
    }
}