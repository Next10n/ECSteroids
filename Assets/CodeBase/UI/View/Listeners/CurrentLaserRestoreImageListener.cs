using UnityEngine;
using UnityEngine.UI;

namespace UI.View.Listeners
{
    public class CurrentLaserRestoreImageListener : UnityGameView, ICurrentLaserRestoreTimeListener
    {
        [SerializeField] private Image _progress;
        
        public override void InitializeView(GameEntity gameEntity)
        {
            base.InitializeView(gameEntity);
            gameEntity.AddCurrentLaserRestoreTimeListener(this);
        }
        
        public void OnCurrentLaserRestoreTime(GameEntity entity, float value)
        {
            _progress.fillAmount = 1 - (entity.laserRestoreTime.Value - value) / entity.laserRestoreTime.Value;
        }
    }
}