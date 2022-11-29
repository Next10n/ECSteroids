namespace Core.Game.Systems.Score
{
    public sealed class ScoreSystems : Feature
    {
        public ScoreSystems(Contexts contexts)
        {
            Add(new AddScoreSystem(contexts));
            Add(new ResetScoreSystems(contexts));
        }
    }
}