public abstract class State
{
    protected PlayerStateMachine stateMachine;
    protected PlayerBlackboard blackboard;

    public State(PlayerStateMachine stateMachine, PlayerBlackboard blackboard)
    {
        this.stateMachine = stateMachine;
        this.blackboard = blackboard;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
}