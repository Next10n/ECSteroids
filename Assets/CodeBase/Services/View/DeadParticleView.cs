using UnityEngine;

namespace Services.View
{
    public class DeadParticleView : DeadListener
    {
        [SerializeField] private GameObject _destroyParticle;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public override void OnDead(GameEntity entity)
        {
            entity.RemoveDeadListener(this);
            _spriteRenderer.enabled = false;
            _destroyParticle.SetActive(true);
        }
    }
}