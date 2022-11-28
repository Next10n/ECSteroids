using TMPro;
using UnityEngine;

namespace UI
{
    public class PositionTextView : PositionListener
    {
        [SerializeField] private TMP_Text _text;
        
        public override void OnPosition(GameEntity entity, Vector2 value)
        {
            _text.text = $"Position : {value}";
        }
    }
}