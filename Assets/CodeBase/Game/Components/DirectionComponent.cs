using Entitas;
using UnityEngine;

namespace Game.Components
{
    [Game]
    public sealed class DirectionComponent : IComponent
    {
        public Vector2 Value;
    }
}