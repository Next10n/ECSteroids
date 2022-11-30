using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Core.Game.Components.Movements
{
    [Game, Event(EventTarget.Self)]
    public sealed class VelocityComponent : IComponent
    {
        public Vector2 Value;
    }
}