using Entitas;

namespace Core.Game.Components.Enemies
{
    [Game]
    public sealed class AddScoreComponent : IComponent
    {
        public int Value;
    }
}