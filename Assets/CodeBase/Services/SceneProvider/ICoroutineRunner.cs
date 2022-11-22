using System.Collections;
using UnityEngine;
using Views.Systems;

namespace Services.SceneProvider
{
    public interface ICoroutineRunner : IService
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}