using UnityEngine;

namespace Services.View
{
    public class RotationTransformView : RotationListener
    {
        public override void InitializeView(Contexts contexts, GameEntity entity)
        {
            base.InitializeView(contexts, entity);
            Entity.AddRotationAngleListener(this);
        }
        
        public override void OnRotationAngle(GameEntity entity, float value)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, value);
        }
    }
}