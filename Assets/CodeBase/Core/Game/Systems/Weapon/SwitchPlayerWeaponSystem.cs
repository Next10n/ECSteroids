using Entitas;

namespace Core.Game.Systems.Weapon
{
    public class SwitchPlayerWeaponSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _playerWeapons;
        private readonly IGroup<InputEntity> _switchWeaponInput;

        public SwitchPlayerWeaponSystem(Contexts contexts)
        {
            _switchWeaponInput = contexts.input.GetGroup(InputMatcher.SwitchWeaponInput);
            _playerWeapons = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player).AnyOf(GameMatcher.BulletWeapon, GameMatcher.LaserWeapon));
        }
        
        public void Execute()
        {
            foreach(InputEntity inputEntity in _switchWeaponInput)
            foreach(GameEntity entity in _playerWeapons) 
                entity.isSwitchWeapon = true;
        }
    }
}