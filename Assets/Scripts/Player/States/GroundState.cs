using UnityEngine.InputSystem;
using UnityEngine;

public class GroundState : State
{
    public GroundState(PlayerStateMachine stateMachine, PlayerBlackboard blackboard) : base(stateMachine, blackboard) {}

    public override void Enter()
    {
        base.Enter();
        blackboard.PlayerControls.Gameplay.Jump.started += SwitchToJumpState;
    }

    public override void Exit()
    {
        base.Exit();
        blackboard.PlayerControls.Gameplay.Jump.started -= SwitchToJumpState;
    }

    private void SwitchToJumpState(InputAction.CallbackContext context)
    {
        Debug.Log("Mudando pro jumpstate");
        if (blackboard.IsGrounded)
        {
            Debug.Log("Entrando no isgrounded");
            stateMachine.SwitchState(typeof(JumpState));
        }
    }
}