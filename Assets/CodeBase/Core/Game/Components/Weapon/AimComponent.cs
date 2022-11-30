using Entitas;
using UnityEngine;

namespace Core.Game.Components.Weapon
{
    [Game]
    public sealed class AimComponent : IComponent
    {
        public Transform Value;
    }
}