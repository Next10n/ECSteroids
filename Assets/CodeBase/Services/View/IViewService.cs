namespace Services.View
{
    public interface IViewService : IService
    {
        void CreateView(Contexts contexts, GameEntity entity, string assetName);
    }
}