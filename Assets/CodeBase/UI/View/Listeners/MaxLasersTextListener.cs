using TMPro;
using UnityEngine;

namespace UI.View.Listeners
{
    public class MaxLasersTextListener : UnityGameView, IMaxLasersWeaponListener
    {
        [SerializeField] private TMP_Text _maxLasers;
        
        public override void InitializeView(GameEntity gameEntity)
        {
            base.InitializeView(gameEntity);
            gameEntity.AddMaxLasersWeaponListener(this);
            OnMaxLasersWeapon(gameEntity, gameEntity.maxLasersWeapon.Value);
        }

        public void OnMaxLasersWeapon(GameEntity entity, int value)
        {
            _maxLasers.text = value.ToString();
        }
    }
}