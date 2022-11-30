using UnityEngine;

namespace View.UnityView.Listeners
{
    public class PositionTransformListener : PositionListener
    {
        public override void OnPosition(GameEntity entity, Vector2 value)
        {
            transform.position = value;
        }
    }
}