using Views.Systems;

namespace Services.Time
{
    public interface ITimeService : IService
    {
        float DeltaTime { get; }
    }
}