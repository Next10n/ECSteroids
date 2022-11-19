using Entitas;
using Entitas.CodeGeneration.Attributes;
using Services.Time;
 
namespace Services.Components
{
    [Meta, Unique]
    public sealed class TimeServiceComponent :  IComponent
    {
        public ITimeService Value;
    }
}