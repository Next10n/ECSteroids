using Entitas;

namespace Services.Systems
{
    public class RegisterCameraProviderSystem : IInitializeSystem
    {
        private readonly MetaContext _context;
        private readonly ICameraProvider _cameraProvider;

        public RegisterCameraProviderSystem(Contexts contexts, ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
            _context = contexts.meta;
        }

        public void Initialize()
        {
            _context.ReplaceCameraProvider(_cameraProvider);
        }
    }
}