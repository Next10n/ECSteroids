using UnityEngine;
using Views.Systems;

namespace Services
{
    public interface ICameraProvider : IService
    {
        Bounds GetMainCameraBounds();
    }
}