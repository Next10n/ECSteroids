using System.Collections;

namespace Infrastructure.Services.Coroutine
{
    public interface ICoroutineRunner
    {
        UnityEngine.Coroutine StartCoroutine(IEnumerator coroutine);
    }
}