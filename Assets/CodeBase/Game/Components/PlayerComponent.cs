using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Game.Components
{
    [Game]
    public sealed class PlayerComponent : IComponent
    {
    }
    
    [Game]
    public sealed class AngularSpeedComponent : IComponent
    {
        public float Value;
    }
    
    [Game]
    public sealed class AccelerationComponent : IComponent
    {
        public float Value;
    }
    
    [Game]
    public sealed class AccelerationSpeedComponent : IComponent
    {
        public float Value;
    }
    
    [Game]
    public sealed class TeleportableComponent : IComponent
    {
    }
    
    [Game, Cleanup(CleanupMode.RemoveComponent)]
    public sealed class TriggeredComponent : IComponent
    {
        public int Value;
    }
    
    [Game]
    public sealed class EnemyComponent : IComponent
    {
    }
    
    [Game, Cleanup(CleanupMode.DestroyEntity), Event(EventTarget.Self)]
    public sealed class DestroyEntityComponent : IComponent
    {
    }
    
    [Game]
    public sealed class AimComponent : IComponent
    {
        public Transform Value;
    }
    
    
    
    
    
    
}