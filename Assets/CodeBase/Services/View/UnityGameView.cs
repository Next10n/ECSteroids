using UnityEngine;

namespace Services.View
{
    public abstract class UnityGameView : MonoBehaviour//, IViewController
    {
        protected GameEntity Entity;
        protected Contexts Contexts;
        
        // public Vector2 Position { get => transform.position; set => transform.position = value; }
        public virtual void InitializeView(Contexts contexts, GameEntity entity)
        {
            Contexts = contexts;
            Entity = entity;
        }

        public virtual void DestroyView()
        {
            Destroy(gameObject);
        }
    }
}