using TMPro;
using UnityEngine;

namespace View.UnityView.Listeners
{
    public class PositionTextListener : PositionListener
    {
        [SerializeField] private TMP_Text _text;
        
        public override void OnPosition(GameEntity entity, Vector2 value)
        {
            _text.text = $"Position : {value}";
        }
    }
}