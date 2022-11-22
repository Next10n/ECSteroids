using Services;

namespace Game.Factories
{
    public interface IEnemyFactory : IService
    {
        void Initialize(int playerIndex);
        GameEntity CreateAsteroid();
        GameEntity CreateUfo();
    }
}