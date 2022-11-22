using UnityEngine;

namespace Services
{
    public interface ICameraProvider : IService
    {
        Bounds GetMainCameraBounds();
    }
}