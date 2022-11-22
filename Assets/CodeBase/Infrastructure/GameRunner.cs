using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        private const string InitialScene = "Init";

        private void Awake()
        {
            if (FindObjectOfType<GameBootstrapper>() == null)
                SceneManager.LoadScene(InitialScene);
        }
    }
}