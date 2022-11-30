namespace Core.Game.Systems.View
{
    public sealed class ViewSystems : Feature
    {
        public ViewSystems(Contexts contexts)
        {
            Add(new CreateAssetViewSystem(contexts.game, contexts));
            Add(new GetPoolViewSystem(contexts));
            Add(new ShowResultSystem(contexts));
        }
    }
}