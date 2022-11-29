namespace Infrastructure.Services.Input
{
    public interface IInputService
    {
        float HorizontalAxis { get; }
        bool AccelerationKeyDown { get; }
        bool ShootKeyDown { get; }
        bool SwitchWeaponKeyDown { get; }
    }
}