using UnityEngine;

namespace Services.View
{
    public class DeadView : UnityGameView, IDeadListener
    {
        [SerializeField] private GameObject _destroyParticle;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public override void InitializeView(Contexts contexts, GameEntity entity)
        {
            base.InitializeView(contexts, entity);
            entity.AddDeadListener(this);
        }

        public void OnDead(GameEntity entity)
        {
            _spriteRenderer.enabled = false;
            _destroyParticle.SetActive(true);
            Destroy(gameObject, 2f);
        }
    }
}