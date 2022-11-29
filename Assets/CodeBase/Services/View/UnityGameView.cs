using UnityEngine;

namespace Services.View
{
    public abstract class UnityGameView : MonoBehaviour, IDestroyEntityListener
    {
        public GameEntity Entity { get; private set; }

        public virtual void InitializeView(GameEntity entity)
        {
            Entity = entity;
            Entity.AddDestroyEntityListener(this);
        }

        public virtual void OnDestroyEntity(GameEntity entity)
        {
            Entity.RemoveDestroyEntityListener(this);
        }
    }
}