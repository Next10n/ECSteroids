using UnityEngine;

namespace Services.View
{
    public class Trigger2DGameView : UnityGameView
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.TryGetComponent(out UnityGameView unityGameView))
            {
                Entity.AddTriggered(unityGameView.EntityIndex);
            }
        }
    }
}