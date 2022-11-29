using Entitas;
using Entitas.CodeGeneration.Attributes;
using Infrastructure.Services.Windows;

namespace Core.Meta.Components
{
    [Meta, Unique]
    public sealed class WindowServiceComponent :  IComponent
    {
        public IWindowService Value;
    }
}