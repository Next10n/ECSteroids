using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Game.Components
{
    [Game, Event(EventTarget.Self)]
    public struct PositionComponent : IComponent
    {
        public Vector2 Value;
    }
}