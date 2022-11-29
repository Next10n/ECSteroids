namespace Services
{
    public interface IRandomProvider : IService
    {
        float Random(float min, float max);
        int Random(int min, int max);
        bool RandomFlag();
    }
}