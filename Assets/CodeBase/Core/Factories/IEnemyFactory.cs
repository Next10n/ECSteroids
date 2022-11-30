using Core.Game.Components;
using Core.Game.Components.Enemies;

namespace Core.Factories
{
    public interface IEnemyFactory
    {
        void Initialize(GameContext gameContext, int playerIndex);
        GameEntity Create(EnemyType enemyType);
    }
}