using Infrastructure.StateMachine;
using UI;

namespace Services.Windows
{
    public interface IWindowFactory
    {
        PlayerHud CreateHud();
        ResultWindow CreateResultWindow();
        void Initialize(IStateMachine stateMachine, Contexts contexts);
    }
}