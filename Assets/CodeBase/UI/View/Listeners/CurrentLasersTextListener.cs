using TMPro;
using UnityEngine;

namespace UI.View.Listeners
{
    public class CurrentLasersTextListener : UnityGameView, ILaserStorageListener
    {
        [SerializeField] private TMP_Text _currentLasers;
        
        public override void InitializeView(GameEntity gameEntity)
        {
            base.InitializeView(gameEntity);
            gameEntity.AddLaserStorageListener(this);
            OnLaserStorage(gameEntity, gameEntity.laserStorage.Value);
        }
        
        public void OnLaserStorage(GameEntity entity, int value)
        {
            _currentLasers.text = value.ToString();
        }
    }
}