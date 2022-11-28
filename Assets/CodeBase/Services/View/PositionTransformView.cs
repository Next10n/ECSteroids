using UI;
using UnityEngine;

namespace Services.View
{
    public class PositionTransformView : PositionListener
    {
        public override void OnPosition(GameEntity entity, Vector2 value)
        {
            transform.position = value;
        }
    }
}