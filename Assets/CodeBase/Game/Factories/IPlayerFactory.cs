using Services;

namespace Game.Factories
{
    public interface IPlayerFactory : IService
    {
        GameEntity Create(/* player data */);
    }
}