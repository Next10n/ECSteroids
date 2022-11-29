namespace Infrastructure.Services
{
    public interface IRandomProvider
    {
        float Random(float min, float max);
        int Random(int min, int max);
        bool RandomFlag();
    }
}