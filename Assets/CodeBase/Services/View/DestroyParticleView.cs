using UnityEngine;

namespace Services.View
{
    public class DestroyParticleView : UnityGameView
    {
        [SerializeField] private GameObject _destroyParticle;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public override void OnDestroyEntity(GameEntity entity)
        {
            _spriteRenderer.enabled = false;
            _destroyParticle.SetActive(true);
        }
    }
}