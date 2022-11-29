using Core.Game.Components;

namespace Core.Factories
{
    public interface IEnemyFactory
    {
        void Initialize(GameContext gameContext, int playerIndex);
        GameEntity Create(EnemyType enemyType);
    }
}