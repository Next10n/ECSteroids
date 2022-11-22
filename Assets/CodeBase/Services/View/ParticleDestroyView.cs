using UnityEngine;

namespace Services.View
{
    public class ParticleDestroyView : UnityGameView, IDestroyedListener
    {
        [SerializeField] private GameObject _destroyParticle;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public override void InitializeView(Contexts contexts, GameEntity entity)
        {
            base.InitializeView(contexts, entity);
            entity.AddDestroyedListener(this);
        }

        public void OnDestroyed(GameEntity entity)
        {
            _spriteRenderer.enabled = false;
            _destroyParticle.SetActive(true);
            Destroy(gameObject, 2f);
        }
    }
}