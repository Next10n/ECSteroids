using UnityEngine;

namespace Infrastructure.StateMachine.Gameplay
{
    public class RestartState : IGameplayState
    {
        public void Enter()
        {
            Debug.Log("Restart game");
            // respawn player
            // reinitialize enemy Factory and Hud
        }

        public void Exit()
        {
        }
    }
}