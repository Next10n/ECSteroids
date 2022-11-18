using Entitas;
using Services.AssetProvider;

namespace Views.Components
{
    [View]
    public sealed class ViewComponent : IComponent
    {
        public IViewController Value;
    }
}