using UnityEngine;

public class IdleState : GroundState
{
    public IdleState(PlayerStateMachine stateMachine, PlayerBlackboard blackboard) : base(stateMachine, blackboard) {}

    public override void Enter()
    {
        base.Enter();
        blackboard.Body.linearVelocity = new Vector2(0, blackboard.Body.linearVelocity.y);
        blackboard.PlayerAnimator.SetBool("isRunning", false);
    }

    public override void Update()
    {
        base.Update();
        if (Mathf.Abs(blackboard.PlayerControls.Gameplay.Move.ReadValue<Vector2>().x) > 0.1f)
        {
            stateMachine.SwitchState(typeof(RunState));
        }
    }
}