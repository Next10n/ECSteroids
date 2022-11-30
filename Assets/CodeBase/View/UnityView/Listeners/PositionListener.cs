using UnityEngine;

namespace View.UnityView.Listeners
{
    public abstract class PositionListener : UnityGameView, IPositionListener
    {
        public override void InitializeView(GameEntity entity)
        {
            base.InitializeView(entity);
            entity.AddPositionListener(this);
        }
        
        public abstract void OnPosition(GameEntity entity, Vector2 value);
    }
}