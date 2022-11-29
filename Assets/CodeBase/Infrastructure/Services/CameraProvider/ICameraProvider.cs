using UnityEngine;

namespace Infrastructure.Services
{
    public interface ICameraProvider
    {
        Bounds GetMainCameraBounds();
    }
}