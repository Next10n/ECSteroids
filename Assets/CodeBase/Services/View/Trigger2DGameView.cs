using UnityEngine;

namespace Services.View
{
    public class Trigger2DGameView : UnityGameView
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if(Entity.isEnabled == false)
                return;
            
            if(col.TryGetComponent(out UnityGameView unityGameView))
            {
                unityGameView.Entity.AddTriggered(Entity.creationIndex);
                Entity.AddTriggered(unityGameView.Entity.creationIndex);
            }
        }
    }
}