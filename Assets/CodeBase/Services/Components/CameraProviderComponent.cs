using Entitas;
using Entitas.CodeGeneration.Attributes;
using Services.Input;

namespace Services.Components
{
    [Meta, Unique]
    public sealed class CameraProviderComponent :  IComponent
    {
        public ICameraProvider Value;
    }
}