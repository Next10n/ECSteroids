using Infrastructure.StateMachine;
using UI;

namespace Services.Windows
{
    public interface IWindowFactory
    {
        void InitCanvas();
        PlayerHud CreateHud();
        ResultWindow CreateResultWindow();
        void Initialize(IStateMachine stateMachine);
    }
}