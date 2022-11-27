using Infrastructure.StateMachine;
using UI;

namespace Services.Windows
{
    public interface IWindowService : IService
    {
        void Initialize();
        PlayerHud CreateHud();
        void ShowResult();
        void HideResult();
        void InitializeStateMachine(IStateMachine stateMachine);
    }
}