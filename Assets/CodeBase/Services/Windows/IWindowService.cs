using UI;

namespace Services.Windows
{
    public interface IWindowService : IService
    {
        void Initialize();
        PlayerHud CreateHud();
    }
}