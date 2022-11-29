using Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        private void Awake()
        {
            if (FindObjectOfType<GameBootstrapper>() == null)
                SceneManager.LoadScene(Constants.InitScene);
        }
    }
}