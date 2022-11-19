using UnityEngine;

namespace Services.Input
{
    public class UnityInputService : IInputService
    {
        public float HorizontalAxis => UnityEngine.Input.GetAxis("Horizontal");
        public bool AccelerationKeyDown => UnityEngine.Input.GetAxis("Vertical") > 0f;
        public bool ShootKeyDown => UnityEngine.Input.GetKeyDown(KeyCode.Space);
        public bool SwitchWeaponKeyDown => UnityEngine.Input.GetKeyDown(KeyCode.Q);
    }
}