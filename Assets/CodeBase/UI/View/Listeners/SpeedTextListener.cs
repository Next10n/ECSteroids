using TMPro;
using UnityEngine;

namespace UI.View.Listeners
{
    public class SpeedTextListener : UnityGameView, IVelocityListener
    {
        [SerializeField] private TMP_Text _text;

        public override void InitializeView(GameEntity entity)
        {
            base.InitializeView(entity);
            entity.AddVelocityListener(this);
        }

        public void OnVelocity(GameEntity entity, Vector2 value)
        {
            _text.text = $"Speed : {value.magnitude}";
        }
    }
}