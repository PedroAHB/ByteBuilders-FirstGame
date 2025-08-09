using System;
using System.Collections.Generic;

public class PlayerStateMachine
{
    public State CurrentState { get; private set; }
    private Dictionary<Type, State> states = new Dictionary<Type, State>();

    public PlayerStateMachine(PlayerBlackboard blackboard)
    {
        states.Add(typeof(IdleState), new IdleState(this, blackboard));
        states.Add(typeof(RunState), new RunState(this, blackboard));
        states.Add(typeof(JumpState), new JumpState(this, blackboard));
        states.Add(typeof(GroundState), new GroundState(this, blackboard));
    }

    public void Initialize(Type startingState)
    {
        CurrentState = states[startingState];
        CurrentState.Enter();
    }

    public void SwitchState(Type newState)
    {
        CurrentState.Exit();
        CurrentState = states[newState];
        CurrentState.Enter();
    }

    public void Update()
    {
        CurrentState?.Update();
    }

    public void FixedUpdate()
    {
        CurrentState?.FixedUpdate();
    }
}