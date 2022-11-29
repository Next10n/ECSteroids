namespace Infrastructure.Services.Windows
{
    public interface IWindowService
    {
        void ShowHud();
        void InitializeHud(Contexts contexts, GameEntity player);
        void ShowResult();
        void HideResult();
    }
}