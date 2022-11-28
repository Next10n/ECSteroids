using StaticData;

namespace Game.Factories
{
    public interface IPlayerFactory
    {
        GameEntity Create(PlayerStaticData playerStaticData);
        void Initialize(GameContext gameContext);
    }
}