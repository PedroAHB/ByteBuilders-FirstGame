using UnityEngine;

public class RunState : GroundState
{
    public RunState(PlayerStateMachine stateMachine, PlayerBlackboard blackboard) : base(stateMachine, blackboard) {}

    public override void Enter()
    {
        base.Enter();
        blackboard.PlayerAnimator.SetBool("isRunning", true);
    }

    public override void Exit()
    {
        base.Exit();
        blackboard.PlayerAnimator.SetBool("isRunning", false);
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
        if (Mathf.Abs(blackboard.PlayerControls.Gameplay.Move.ReadValue<Vector2>().x) < 0.1f)
        {
            stateMachine.SwitchState(typeof(IdleState));
        }
    }
}