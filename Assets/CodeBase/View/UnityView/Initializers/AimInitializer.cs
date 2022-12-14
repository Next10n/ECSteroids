using UnityEngine;

namespace View.UnityView.Initializers
{
    public class AimInitializer : UnityGameView
    {
        [SerializeField] private Transform _aim;

        public override void InitializeView(GameEntity entity)
        {
            base.InitializeView(entity);
            entity.AddAim(_aim);
        }
    }
}