using System;
using System.Collections;
using Infrastructure.Services.Coroutine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services.SceneProvider
{
    public class UnitySceneProvider : ISceneProvider
    {
        private readonly ICoroutineRunner _coroutineRunner;
        public UnitySceneProvider(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string sceneName, Action onLoad = null)
        {
            _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoad));
        }
        private IEnumerator LoadScene(string nextScene, Action onLoaded = null)
        {
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

            while (!waitNextScene.isDone)
                yield return null;
      
            onLoaded?.Invoke();
        }

    }
}