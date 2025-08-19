using UnityEngine;

public class InputEventsUI
{
    public class NavigateInputEvent : GameEvent { public Vector2 Value; }
    public class SubmitInputEvent : GameEvent { }
    public class ClickInputEvent : GameEvent { }
    public class RightClickInputEvent : GameEvent { }
    public class MiddleClickInputEvent : GameEvent { }
    public class ScrollWheelInputEvent : GameEvent { public Vector2 ScrollDelta; }
    public class PointerInputEvent : GameEvent { public Vector2 Position; }
    public class TrackedDevicePositionEvent : GameEvent { public Vector3 Position; }
    public class TrackedDeviceOrientationEvent : GameEvent { public Quaternion Rotation; }   
}