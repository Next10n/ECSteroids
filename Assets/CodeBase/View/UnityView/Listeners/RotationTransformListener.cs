using UnityEngine;

namespace View.UnityView.Listeners
{
    public class RotationTransformListener : RotationListener
    {
        public override void OnRotationAngle(GameEntity entity, float value)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, value);
        }
    }
}