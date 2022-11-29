namespace Infrastructure.Services
{
    public class UnityRandomProvider : IRandomProvider
    {
        public float Random(float min, float max)
        {
            return UnityEngine.Random.Range(min, max);
        }

        public int Random(int min, int max)
        {
            return UnityEngine.Random.Range(min, max + 1);
        }

        public bool RandomFlag()
        {
            return UnityEngine.Random.Range(0, 2) == 0;
        }
    }
}