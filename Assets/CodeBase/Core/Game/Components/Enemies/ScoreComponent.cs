using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Core.Game.Components.Enemies
{
    [Game, Unique, Event(EventTarget.Self)]
    public sealed class ScoreComponent : IComponent
    {
        public int Value;
    }
}