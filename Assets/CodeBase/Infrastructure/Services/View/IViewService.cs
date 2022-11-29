namespace Infrastructure.Services.View
{
    public interface IViewService
    {
        void CreateView(Contexts contexts, GameEntity entity, string assetName);
    }
}