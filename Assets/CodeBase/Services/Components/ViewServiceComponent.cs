using Entitas;
using Entitas.CodeGeneration.Attributes;
using Services.View;

namespace Services.Components
{
    [Meta, Unique]
    public sealed class ViewServiceComponent :  IComponent
    {
        public IViewService Value;
    }
}