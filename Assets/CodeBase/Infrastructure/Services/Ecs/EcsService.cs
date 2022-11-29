using Core;
using Core.Factories;
using Core.Game.Systems;
using Infrastructure.Services.Input;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.Time;
using Infrastructure.Services.View;
using Infrastructure.Services.Windows;

namespace Infrastructure.Services.Ecs
{
    public class EcsService : IEcsService
    {
        private readonly IViewService _viewService;
        private readonly ITimeService _timeService;
        private readonly IInputService _inputService;
        private readonly ICameraProvider _cameraProvider;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IWindowService _windowService;
        private readonly IBulletFactory _bulletFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly IRandomProvider _randomProvider;

        private AllSystems _allSystems;

        public EcsService(IViewService viewService, ITimeService timeService, IInputService inputService,
            ICameraProvider cameraProvider, IEnemyFactory enemyFactory, IWindowService windowService, IBulletFactory bulletFactory,
            IStaticDataService staticDataService, IRandomProvider randomProvider)
        {
            _viewService = viewService;
            _timeService = timeService;
            _inputService = inputService;
            _cameraProvider = cameraProvider;
            _enemyFactory = enemyFactory;
            _windowService = windowService;
            _bulletFactory = bulletFactory;
            _staticDataService = staticDataService;
            _randomProvider = randomProvider;
        }

        public Contexts CreateEcsWorld()
        {
            Contexts contexts = new Contexts();
            _allSystems = new AllSystems(contexts, _viewService, _timeService, _inputService, _cameraProvider, _enemyFactory, _windowService,
                _bulletFactory, _staticDataService, _randomProvider);
            _allSystems.Initialize();
            return contexts;
        }

        public void Update()
        {
            _allSystems.Execute();
            _allSystems.Cleanup();
        }
    }
}