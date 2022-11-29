using Entitas;
using Entitas.CodeGeneration.Attributes;
using Services.StaticData;

namespace Services.Components
{
    [Meta, Unique]
    public sealed class StaticDataServiceComponent :  IComponent
    {
        public IStaticDataService Value;
    }
}