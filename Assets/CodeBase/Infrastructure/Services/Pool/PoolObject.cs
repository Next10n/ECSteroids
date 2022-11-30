using View.UnityView;

namespace Infrastructure.Services.Pool
{
    public class PoolObject : UnityGameView
    {
        private UnityGameView[] _unityGameViews;
        private Pool _pool;
        
        
        public override void InitializeView(GameEntity entity)
        {
            base.InitializeView(entity);
            _unityGameViews ??= GetComponents<UnityGameView>();
            foreach(UnityGameView unityGameView in _unityGameViews)
                if(unityGameView != this)
                    unityGameView.InitializeView(entity);
        }

        public void InitializePool(Pool pool)
        {
            _pool = pool;
        }
        
        public override void OnDestroyEntity(GameEntity entity)
        {
            base.OnDestroyEntity(entity);
            _pool.Return(this);
        }
    }
}