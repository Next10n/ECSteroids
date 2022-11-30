using Infrastructure.Services.StateMachine;
using View.UI;

namespace Infrastructure.Services.Windows
{
    public interface IWindowFactory
    {
        PlayerHud CreateHud();
        ResultWindow CreateResultWindow();
        void Initialize(IStateMachine stateMachine, Contexts contexts);
    }
}