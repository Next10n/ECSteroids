using UnityEngine;

namespace Services.View
{
    public class PositionGameView : UnityGameView, IPositionListener
    {
        public override void InitializeView(Contexts contexts, GameEntity entity)
        {
            base.InitializeView(contexts, entity);
            Entity.AddPositionListener(this);
        }

        public override void DestroyView()
        {
            base.DestroyView();
            Entity.RemovePositionListener(this);
        }

        public void OnPosition(GameEntity entity, Vector2 value)
        {
            transform.position = value;
        }
    }
}