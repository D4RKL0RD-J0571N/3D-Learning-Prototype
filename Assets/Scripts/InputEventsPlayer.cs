using UnityEngine;

public class InputEventsPlayer
{
    public class MoveInputEvent : GameEvent { public Vector2 Value; }
    public class LookInputEvent : GameEvent { public Vector2 Value; }

    public class JumpInputEvent : GameEvent { }
    public class SprintInputEvent : GameEvent { }
    public class AttackInputEvent : GameEvent { }
    public class InteractInputEvent : GameEvent { }
    public class CrouchInputEvent : GameEvent { }
    public class NextInputEvent : GameEvent { }
    public class PreviousInputEvent : GameEvent { }
    public class CancelInputEvent : GameEvent { }
        
}