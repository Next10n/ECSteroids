using UnityEngine;

namespace View.UnityView.Listeners
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