using Views.Systems;

namespace Game.Factories
{
    public interface IEnemyFactory : IService
    {
        void Initialize(GameContext gameContext, int playerIndex);
        GameEntity CreateAsteroid();
        GameEntity CreateUfo();
    }
}