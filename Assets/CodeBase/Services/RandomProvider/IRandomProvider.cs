namespace Services
{
    public interface IRandomProvider : IService
    {
        float Random(float min, float max);
        bool RandomFlag();
    }
}