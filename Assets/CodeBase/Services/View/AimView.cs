using UnityEngine;

namespace Services.View
{
    public class AimView : UnityGameView
    {
        [SerializeField] private Transform _aim;

        public override void InitializeView(GameEntity entity)
        {
            base.InitializeView(entity);
            entity.AddAim(_aim);
        }
    }
}