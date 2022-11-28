using UnityEngine;

namespace Services.View
{
    public abstract class UnityGameView : MonoBehaviour, IDestroyEntityListener
    {
        protected Contexts Contexts;
        public GameEntity Entity { get; private set; }

        public virtual void InitializeView(Contexts contexts, GameEntity entity)
        {
            Contexts = contexts;
            Entity = entity;
            Entity.AddDestroyEntityListener(this);
        }

        public virtual void OnDestroyEntity(GameEntity entity)
        {
            Entity.RemoveDestroyEntityListener(this);
        }
    }
}