using Entitas;
using Entitas.CodeGeneration.Attributes;
using Infrastructure.Services.StaticData;

namespace Core.Meta.Components
{
    [Meta, Unique]
    public sealed class StaticDataServiceComponent :  IComponent
    {
        public IStaticDataService Value;
    }
}