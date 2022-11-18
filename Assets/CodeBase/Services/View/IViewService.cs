using Entitas;
using Services.AssetProvider;
using Views.Systems;

namespace Services.View
{
    public interface IViewService : IService
    {
        IViewController CreateView(Contexts contexts, IEntity entity, string assetName);
    }
}