using Actors;

public class CoreEvents
{
    public class PlayerLevelUpEvent : GameEvent { public int PlayerLevel; }
    public class ActorQueriedEvent : GameEvent { public Actor Actor; }
}