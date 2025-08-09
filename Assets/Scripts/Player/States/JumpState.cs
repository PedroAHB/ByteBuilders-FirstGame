using UnityEngine;

public class JumpState : State
{
    public JumpState(PlayerStateMachine stateMachine, PlayerBlackboard blackboard) : base(stateMachine, blackboard) {}

    public override void Enter()
    {
        base.Enter();
        blackboard.Body.linearVelocity = new Vector2(blackboard.Body.linearVelocity.x, blackboard.JumpVelocity);
        blackboard.PlayerAnimator.SetTrigger("doJump");
    }
    public override void Exit()
    {
        base.Exit();
        blackboard.PlayerAnimator.ResetTrigger("doJump");
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        float moveInput = blackboard.PlayerControls.Gameplay.Move.ReadValue<Vector2>().x;
        blackboard.Body.linearVelocity = new Vector2(moveInput * blackboard.RunVelocity, blackboard.Body.linearVelocity.y);

        if (moveInput != 0)
        {
            blackboard.transform.localScale = new Vector3(Mathf.Sign(moveInput), 1, 1);
        }
    }
    public override void Update()
    {
        base.Update();
        if (blackboard.Body.linearVelocity.y <= 0.01f && blackboard.IsGrounded)
        {
            stateMachine.SwitchState(typeof(IdleState));
        }
    }
}