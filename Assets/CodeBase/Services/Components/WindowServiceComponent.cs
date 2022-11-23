using Entitas;
using Entitas.CodeGeneration.Attributes;
using Services.Windows;

namespace Services.Components
{
    [Meta, Unique]
    public sealed class WindowServiceComponent :  IComponent
    {
        public IWindowService Value;
    }
}