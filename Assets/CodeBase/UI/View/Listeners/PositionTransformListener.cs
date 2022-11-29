using UnityEngine;

namespace UI.View.Listeners
{
    public class PositionTransformListener : PositionListener
    {
        public override void OnPosition(GameEntity entity, Vector2 value)
        {
            transform.position = value;
        }
    }
}