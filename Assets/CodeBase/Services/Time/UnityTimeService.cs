namespace Services.Time
{
    public class UnityTimeService : ITimeService
    {
        public float DeltaTime => UnityEngine.Time.deltaTime;
    }
}