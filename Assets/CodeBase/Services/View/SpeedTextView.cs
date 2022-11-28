using TMPro;
using UnityEngine;

namespace Services.View
{
    public class SpeedTextView : UnityGameView, IVelocityListener
    {
        [SerializeField] private TMP_Text _text;

        public override void InitializeView(Contexts contexts, GameEntity entity)
        {
            base.InitializeView(contexts, entity);
            entity.AddVelocityListener(this);
        }

        public void OnVelocity(GameEntity entity, Vector2 value)
        {
            _text.text = $"Speed : {value.magnitude}";
        }
    }
}