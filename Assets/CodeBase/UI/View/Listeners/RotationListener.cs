namespace UI.View.Listeners
{
    public abstract class RotationListener : UnityGameView, IRotationAngleListener
    {
        public override void InitializeView(GameEntity entity)
        {
            base.InitializeView(entity);
            Entity.AddRotationAngleListener(this);
            OnRotationAngle(entity, entity.rotationAngle.Value);
        }
        
        public abstract void OnRotationAngle(GameEntity entity, float value);
    }
}