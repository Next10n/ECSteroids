using Entitas;
using Entitas.CodeGeneration.Attributes;
using Services.Input;

namespace Services.Components
{
    [Meta, Unique]
    public sealed class InputServiceComponent :  IComponent
    {
        public IInputService Value;
    }
}