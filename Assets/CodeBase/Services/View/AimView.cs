using UnityEngine;

namespace Services.View
{
    public class AimView : UnityGameView
    {
        [SerializeField] private Transform _aim;

        public override void InitializeView(Contexts contexts, GameEntity entity)
        {
            base.InitializeView(contexts, entity);
            entity.AddAim(_aim);
        }
    }
}