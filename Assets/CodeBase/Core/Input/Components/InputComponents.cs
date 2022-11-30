using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Core.Input.Components
{
    [Input, Unique, Cleanup(CleanupMode.RemoveComponent)]
    public sealed class ShootInputComponent : IComponent
    {
        
    }
    
    [Input, Unique, Cleanup(CleanupMode.RemoveComponent)]
    public sealed class SwitchWeaponInputComponent : IComponent
    {
        
    }
    
    [Input, Unique, Cleanup(CleanupMode.RemoveComponent)]
    public sealed class AccelerationInputComponent : IComponent
    {
        
    }
    
    [Input, Unique, Cleanup(CleanupMode.RemoveComponent)]
    public sealed class HorizontalInputComponent : IComponent
    {
        public float Value;
    }
}