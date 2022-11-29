using Core.Game.Systems.DestroySystems;

namespace Core.Game.Systems
{
    public sealed class GameplaySystems : Feature
    {
        public GameplaySystems(Contexts contexts)
        {
            Add(new DestroySystem(contexts));
            Add(new ScoreSystems.ScoreSystems(contexts));
        }
    }
}