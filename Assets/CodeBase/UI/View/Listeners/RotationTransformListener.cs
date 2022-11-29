using UnityEngine;

namespace UI.View.Listeners
{
    public class RotationTransformListener : RotationListener
    {
        public override void OnRotationAngle(GameEntity entity, float value)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, value);
        }
    }
}