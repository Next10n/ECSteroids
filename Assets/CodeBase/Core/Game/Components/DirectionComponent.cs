using Entitas;
using UnityEngine;

namespace Core.Game.Components
{
    [Game]
    public sealed class DirectionComponent : IComponent
    {
        public Vector2 Value;
    }
}