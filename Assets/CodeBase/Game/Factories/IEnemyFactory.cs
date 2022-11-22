using Views.Systems;

namespace Game.Factories
{
    public interface IEnemyFactory : IService
    {
        void Initialize(int index);
        GameEntity CreateAsteroid();
        GameEntity CreateUfo();
    }
}