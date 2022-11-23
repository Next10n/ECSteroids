using Services.View;
using UnityEngine;

namespace UI
{
    public class PlayerHud : MonoBehaviour
    {
        [SerializeField] private UnityGameView[] _gameViews;

        public void Initialize(Contexts contexts, GameEntity entity)
        {
            foreach (UnityGameView unityGameView in _gameViews)
            {
                unityGameView.InitializeView(contexts, entity);
            }
        }   
    }
}