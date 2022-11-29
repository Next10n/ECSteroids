using System.Collections.Generic;
using Entitas;
using Game.Components;
using Game.Factories;
using Services;
using Services.StaticData;
using UnityEngine;

namespace Game.Systems.WeaponSystems
{
    public class DestructAsteroidSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private readonly IGroup<GameEntity> _bullets;
        private readonly Contexts _contexts;
        private IEnemyFactory _enemyFactory;
        private IRandomProvider _randomProvider;
        private IStaticDataService _staticDataService;

        public DestructAsteroidSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
            _bullets = contexts.game.GetGroup(GameMatcher.Bullet);
        }

        public void Initialize()
        {
            _enemyFactory = _contexts.meta.enemyFactory.Value;
            _randomProvider = _contexts.meta.randomProvider.Value;
            _staticDataService = _contexts.meta.staticDataService.Value;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Triggered);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isDestructible;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(GameEntity bullet in _bullets)
            foreach(GameEntity e in entities)
                if(bullet.creationIndex == e.triggered.Value)
                    CreateAsteroidFragments(e);
        }
        
        private void CreateAsteroidFragments(GameEntity asteroid)
        {
            int fragments = _randomProvider.Random(_staticDataService.MinAsteroidFragments, _staticDataService.MaxAsteroidFragments);
            for(int i = 0; i < fragments; i++)
            {
                GameEntity fragment = _enemyFactory.Create(EnemyType.AsteroidFragments);
                fragment.ReplacePosition(asteroid.position.Value);
            }
        }
    }
}