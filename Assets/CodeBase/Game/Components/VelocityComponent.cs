using Entitas;
using UnityEngine;

namespace Game.Components
{
    [Game]
    public sealed class VelocityComponent : IComponent
    {
        public Vector2 Value;
    }
}