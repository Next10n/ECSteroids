using UnityEngine;

namespace UI.View.Listeners
{
    public class DestroyParticleListener : UnityGameView
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