using Entitas;
using Entitas.CodeGeneration.Attributes;
using Infrastructure.Services.Input;

namespace Core.Meta.Components
{
    [Meta, Unique]
    public sealed class InputServiceComponent :  IComponent
    {
        public IInputService Value;
    }
}