using Entitas;
using Entitas.CodeGeneration.Attributes;
using Infrastructure.Services.Time;

namespace Core.Meta.Components
{
    [Meta, Unique]
    public sealed class TimeServiceComponent :  IComponent
    {
        public ITimeService Value;
    }
}