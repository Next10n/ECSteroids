using Extensions;
using UnityEngine;

namespace Infrastructure.Services
{
    public class UnityCameraProvider : ICameraProvider
    {
        public Bounds GetMainCameraBounds()
        {
            return Camera.main.OrthographicBounds();
        }
    }
}