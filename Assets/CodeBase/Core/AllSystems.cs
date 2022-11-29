using Core.Factories;
using Core.Game.Systems;
using Core.Game.Systems.View;
using Core.Meta.Systems;
using Infrastructure.Services;
using Infrastructure.Services.Input;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.Time;
using Infrastructure.Services.View;
using Infrastructure.Services.Windows;

namespace Core
{
    public sealed class AllSystems : Feature
    {
        public AllSystems(Contexts contexts, IViewService viewService, ITimeService timeService, IInputService inputService,
            ICameraProvider cameraProvider, IEnemyFactory enemyFactory, IWindowService windowService, IBulletFactory bulletFactory,
            IStaticDataService staticDataService, IRandomProvider randomProvider)
        {
            Add(new RegisterServicesSystem(contexts, viewService, timeService, inputService, cameraProvider, enemyFactory, windowService,
                bulletFactory, staticDataService, randomProvider));
            Add(new GameplaySystems(contexts));
            Add(new ViewSystems(contexts));
            Add(new GameEventSystems(contexts));
            Add(new GameCleanupSystems(contexts));
        }
    }
}