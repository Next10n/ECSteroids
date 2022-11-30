using Entitas;
using Infrastructure.Services.Input;

namespace Core.Input.Systems
{
	public class EmitInputSystem : IExecuteSystem, IInitializeSystem  
	{
		private readonly InputContext _inputContext;
		private readonly Contexts _contexts;
		
		private IInputService _inputService;

		public EmitInputSystem(Contexts contexts)
		{
			_contexts = contexts;
			_inputContext = contexts.input;
		}

		public void Initialize()
		{
			_inputService = _contexts.meta.inputService.Value;
		}

		public void Execute() 
		{
			_inputContext.ReplaceHorizontalInput(_inputService.HorizontalAxis);
			_inputContext.isAccelerationInput = _inputService.AccelerationKeyDown;
			_inputContext.isShootInput = _inputService.ShootKeyDown;
			_inputContext.isSwitchWeaponInput = _inputService.SwitchWeaponKeyDown;
		}
	}
}