using Entitas;
using Extensions;
using Infrastructure.Services.Input;

namespace Core.Game.Systems.Weapon
{
    public class SwitchPlayerWeaponSystem : IExecuteSystem, IInitializeSystem
    {
        private readonly Contexts _contexts;
        
        private IInputService _inputService;
        private IGroup<GameEntity> _player;

        public SwitchPlayerWeaponSystem(Contexts contexts)
        {
            _contexts = contexts;
            _player = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Weapon));
        }

        public void Initialize()
        {
            _inputService = _contexts.meta.inputService.Value;
        }

        public void Execute()
        {
            if(_inputService.SwitchWeaponKeyDown == false)
                return;

            foreach(GameEntity player in _player) 
                player.ReplaceWeapon(player.weapon.Value.Next());
        }
    }
}