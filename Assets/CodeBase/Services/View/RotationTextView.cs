using TMPro;
using UnityEngine;

namespace Services.View
{
    public class RotationTextView : RotationListener
    {
        [SerializeField] private TMP_Text _rotation;
        
        public override void OnRotationAngle(GameEntity entity, float value)
        {
            _rotation.text = $"Rotation Angle {value}";
        }
    }
}