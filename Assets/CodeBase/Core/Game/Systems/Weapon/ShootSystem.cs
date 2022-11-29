using Core.Factories;
using Entitas;
using Infrastructure.Services.Input;

namespace Core.Game.Systems.Weapon
{
    public class ShootSystem : IExecuteSystem, IInitializeSystem
    {
        private IInputService _inputService;
        
        private readonly Contexts _contexts;
        private readonly IGroup<GameEntity> _weaponGroup;
        private IBulletFactory _bulletFactory;

        public ShootSystem(Contexts contexts)
        {
            _contexts = contexts;
            _weaponGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Aim, GameMatcher.Weapon, GameMatcher.Direction));
        }

        public void Initialize()
        {
            _inputService = _contexts.meta.inputService.Value;
            _bulletFactory = _contexts.meta.bulletFactory.Value;
        }
        
        public void Execute()
        {
            if(_inputService.ShootKeyDown == false)
                return;

            foreach(GameEntity entity in _weaponGroup)
            {
                _bulletFactory.Create(entity.weapon.Value, entity);
            }
        }
    }
}