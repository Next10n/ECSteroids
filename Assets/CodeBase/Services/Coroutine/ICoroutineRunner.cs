using System.Collections;

namespace Services.Coroutine
{
    public interface ICoroutineRunner : IService
    {
        UnityEngine.Coroutine StartCoroutine(IEnumerator coroutine);
    }
}