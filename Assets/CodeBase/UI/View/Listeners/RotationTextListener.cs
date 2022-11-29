using TMPro;
using UnityEngine;

namespace UI.View.Listeners
{
    public class RotationTextListener : RotationListener
    {
        [SerializeField] private TMP_Text _rotation;
        
        public override void OnRotationAngle(GameEntity entity, float value)
        {
            _rotation.text = $"Rotation Angle {value}";
        }
    }
}