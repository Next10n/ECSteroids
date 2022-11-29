using System.Collections.Generic;
using Entitas;

namespace Core.Game.Systems.Score
{
    public class AddScoreSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _score;
        private readonly IGroup<GameEntity> _player;

        public AddScoreSystem(Contexts contexts) : base(contexts.game)
        {
            _score = contexts.game.GetGroup(GameMatcher.Score);
            _player = contexts.game.GetGroup(GameMatcher.Player);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.DestroyEntity);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isEnemy && entity.hasAddScore;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(GameEntity players in _player)
            foreach(GameEntity score in _score)
            foreach(GameEntity e in entities)
            {
                int calculateScore = score.score.Value + e.addScore.Value; 
                score.ReplaceScore(calculateScore);
            }
        }
    }
}