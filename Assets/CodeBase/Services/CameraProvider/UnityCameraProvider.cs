using Extensions;
using UnityEngine;

namespace Services
{
    public class UnityCameraProvider : ICameraProvider
    {
        public Bounds GetMainCameraBounds()
        {
            return Camera.main.OrthographicBounds();
        }
    }
}