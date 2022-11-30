using UnityEngine;
using View.UnityView;

namespace View.UI
{
    public class PlayerHud : MonoBehaviour
    {
        [SerializeField] private UnityGameView[] _gameViews;
        [SerializeField] private ContextsView[] _contextsViews;
        
        public void Initialize(Contexts contexts, GameEntity player)
        {
            foreach (UnityGameView unityGameView in _gameViews) 
                unityGameView.InitializeView(player);

            foreach(ContextsView contextsView in _contextsViews) 
                contextsView.InitializeView(contexts);
        }   
    }
}