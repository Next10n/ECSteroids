using Game.Components;
using Services;

namespace Game.Factories
{
    public interface IEnemyFactory : IService
    {
        void Initialize(GameContext gameContext, int playerIndex);
        GameEntity Create(EnemyType enemyType);
    }
}