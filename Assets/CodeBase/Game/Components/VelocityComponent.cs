using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Game.Components
{
    [Game, Event(EventTarget.Self)]
    public sealed class VelocityComponent : IComponent
    {
        public Vector2 Value;
    }
}