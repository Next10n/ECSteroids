using UnityEngine;

namespace Services.View
{
    public abstract class UnityGameView : MonoBehaviour//, IViewController
    {
        protected GameEntity Entity;
        protected Contexts Contexts;

        public int EntityIndex => Entity.creationIndex;
        public virtual void InitializeView(Contexts contexts, GameEntity entity)
        {
            Contexts = contexts;
            Entity = entity;
        }
    }
}