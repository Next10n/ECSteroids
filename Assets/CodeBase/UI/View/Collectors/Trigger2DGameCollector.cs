using UnityEngine;

namespace UI.View.Collectors
{
    public class Trigger2DGameCollector : UnityGameView
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if(Entity.isEnabled == false)
                return;

            if(col.TryGetComponent(out UnityGameView unityGameView))
            {
                if(unityGameView.Entity.isEnabled == false)
                    return;

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