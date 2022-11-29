using Core.Factories;
using Core.Game.Systems.DestroySystems;
using Entitas;
using Infrastructure.Services.Input;

namespace Core.Game.Systems.ScoreSystems
{
    public sealed class WeaponSystems : Feature
    {
        public WeaponSystems(Contexts contexts)
        {
            Add(new ShootSystem(contexts));
            Add(new DestroyBulletSystem(contexts));
        }
    }

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
                GameEntity bullet = _bulletFactory.Create(entity.weapon.Value);
                bullet.AddPosition(entity.aim.Value.position);
                bullet.AddDirection(entity.direction.Value);
                bullet.AddVelocity(entity.direction.Value.normalized * 10f);
                bullet.AddRotationAngle(entity.rotationAngle.Value);
            }
        }
    }
}