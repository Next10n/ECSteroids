namespace Services.Input
{
    public interface IInputService : IService
    {
        float HorizontalAxis { get; }
        
        bool AccelerationKeyDown { get; }
        bool ShootKeyDown { get; }
        bool SwitchWeaponKeyDown { get; }
    }
}