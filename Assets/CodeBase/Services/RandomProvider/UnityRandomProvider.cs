namespace Services
{
    public class UnityRandomProvider : IRandomProvider
    {
        public float Random(float min, float max)
        {
            return UnityEngine.Random.Range(min, max);
        }

        public bool RandomFlag()
        {
            return UnityEngine.Random.Range(0, 2) == 0;
        }
    }
}