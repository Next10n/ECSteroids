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
                if(AlreadyTriggered(unityGameView.Entity, Entity) == false)
                    unityGameView.Entity.ReplaceTriggered(Entity.creationIndex);
                if(AlreadyTriggered(Entity, unityGameView.Entity) == false)
                    Entity.ReplaceTriggered(unityGameView.Entity.creationIndex);
            }
        }

        private bool AlreadyTriggered(GameEntity trigger, GameEntity triggered) => 
            trigger.hasTriggered && trigger.triggered.Value == triggered.creationIndex;
    }
}