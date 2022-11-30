using Entitas;
using UnityEngine;

namespace Core.Game.Components.Movements
{
    [Game]
    public sealed class DirectionComponent : IComponent
    {
        public Vector2 Value;
    }
}