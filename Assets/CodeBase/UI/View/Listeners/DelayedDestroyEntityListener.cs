using UnityEngine;

namespace UI.View.Listeners
{
    public class DelayedDestroyEntityListener : UnityGameView
    {
        [SerializeField] private float _delayTime;

        public override void OnDestroyEntity(GameEntity entity)
        {
            base.OnDestroyEntity(entity);
            Destroy(gameObject, _delayTime);
        }
    }
}