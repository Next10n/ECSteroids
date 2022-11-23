namespace Services.View
{
    public abstract class RotationListener : UnityGameView, IRotationAngleListener
    {
        public override void InitializeView(Contexts contexts, GameEntity entity)
        {
            base.InitializeView(contexts, entity);
            Entity.AddRotationAngleListener(this);
        }

        public abstract void OnRotationAngle(GameEntity entity, float value);
    }
}