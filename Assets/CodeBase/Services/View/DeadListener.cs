namespace Services.View
{
    public abstract class DeadListener : UnityGameView, IDeadListener
    {
        public override void InitializeView(Contexts contexts, GameEntity entity)
        {
            base.InitializeView(contexts, entity);
            entity.AddDeadListener(this);
        }
        
        public abstract void OnDead(GameEntity entity);
    }
}