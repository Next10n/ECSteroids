using UnityEngine;

namespace Infrastructure.StateMachine.Gameplay
{
    public class RestartState : IState
    {
        public void Enter()
        {
            Debug.Log("Restart game");
        }

        public void Exit()
        {
            
        }
    }
}