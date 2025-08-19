using Actors;

public abstract class ActorAction 
{
    public abstract void EnterState(Actor actor);
    public abstract void UpdateState(Actor actor);
    public abstract void ExitState(Actor actor); 
    
}