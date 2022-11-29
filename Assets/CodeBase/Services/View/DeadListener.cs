namespace Services.View
{
    public abstract class DeadListener : UnityGameView, IDeadListener
    {
        public override void InitializeView(GameEntity entity)
        {
            base.InitializeView(entity);
            entity.AddDeadListener(this);
        }
        
        public abstract void OnDead(GameEntity entity);
    }
}