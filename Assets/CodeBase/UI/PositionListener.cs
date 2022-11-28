using Services.View;
using UnityEngine;

namespace UI
{
    public abstract class PositionListener : UnityGameView, IPositionListener
    {
        public override void InitializeView(Contexts contexts, GameEntity entity)
        {
            base.InitializeView(contexts, entity);
            entity.AddPositionListener(this);
        }
        
        public abstract void OnPosition(GameEntity entity, Vector2 value);
    }
}