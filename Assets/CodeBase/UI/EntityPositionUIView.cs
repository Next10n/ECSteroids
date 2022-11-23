using Services.View;
using TMPro;
using UnityEngine;

namespace UI
{
    public class EntityPositionUIView : UnityGameView, IPositionListener
    {
        [SerializeField] private TMP_Text _text;
        public override void InitializeView(Contexts contexts, GameEntity entity)
        {
            base.InitializeView(contexts, entity);
            entity.AddPositionListener(this);
        }

        public void OnPosition(GameEntity entity, Vector2 value)
        {
            _text.text = $"Position : {value}";
        }
    }
}