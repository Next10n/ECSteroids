namespace Services.View
{
    public abstract class RotationListener : UnityGameView, IRotationAngleListener
    {
        public override void InitializeView(GameEntity entity)
        {
            base.InitializeView(entity);
            Entity.AddRotationAngleListener(this);
        }
        
        public abstract void OnRotationAngle(GameEntity entity, float value);
    }
}