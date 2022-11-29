using Entitas;
using Entitas.CodeGeneration.Attributes;
using Infrastructure.Services.View;

namespace Core.Meta.Components
{
    [Meta, Unique]
    public sealed class ViewServiceComponent :  IComponent
    {
        public IViewService Value;
    }
}