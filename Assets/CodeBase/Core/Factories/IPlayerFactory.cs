using StaticData;

namespace Core.Factories
{
    public interface IPlayerFactory
    {
        GameEntity Create(PlayerStaticData playerStaticData);
        void Initialize(GameContext gameContext);
    }
}