using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-100)]
public class InputHandler : MonoBehaviour, InputSystem_Actions.IPlayerActions, InputSystem_Actions.IUIActions
{
    private InputSystem_Actions _inputActions;

    private void Awake() => Initialize();
    private void OnEnable() => EnableInput();
    private void OnDisable() => DisableInput();

    private void Initialize()
    {
        _inputActions = new InputSystem_Actions();
        _inputActions.Player.SetCallbacks(this);
        _inputActions.UI.SetCallbacks(this);
    }

    private void EnableInput()
    {
        _inputActions.Player.Enable();
        _inputActions.UI.Enable();
    }

    private void DisableInput()
    {
        _inputActions.Player.Disable();
        _inputActions.UI.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            GameEventManager.Publish(new InputEventsPlayer.MoveInputEvent { Value = context.ReadValue<Vector2>() });
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            GameEventManager.Publish(new InputEventsPlayer.LookInputEvent { Value = context.ReadValue<Vector2>() });
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            GameEventManager.Publish(new InputEventsPlayer.JumpInputEvent());
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.performed)
            GameEventManager.Publish(new InputEventsPlayer.SprintInputEvent());
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
            GameEventManager.Publish(new InputEventsPlayer.AttackInputEvent());
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
            GameEventManager.Publish(new InputEventsPlayer.InteractInputEvent());
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.performed)
            GameEventManager.Publish(new InputEventsPlayer.CrouchInputEvent());
    }

    public void OnNext(InputAction.CallbackContext context)
    {
        if (context.performed)
            GameEventManager.Publish(new InputEventsPlayer.NextInputEvent());
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
        if (context.performed)
            GameEventManager.Publish(new InputEventsPlayer.PreviousInputEvent());
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        if (context.performed)
            GameEventManager.Publish(new InputEventsPlayer.CancelInputEvent());
    }

    // UI Callbacks (Empty for now)
    public void OnNavigate(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
            GameEventManager.Publish(new InputEventsUI.NavigateInputEvent { Value = context.ReadValue<Vector2>() });
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
        if (context.performed)
            GameEventManager.Publish(new InputEventsUI.SubmitInputEvent());
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
            GameEventManager.Publish(new InputEventsUI.PointerInputEvent { Position = context.ReadValue<Vector2>() });
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
            GameEventManager.Publish(new InputEventsUI.ClickInputEvent());
    }

    public void OnRightClick(InputAction.CallbackContext context)
    {
        if (context.performed)
            GameEventManager.Publish(new InputEventsUI.RightClickInputEvent());
    }

    public void OnMiddleClick(InputAction.CallbackContext context)
    {
        if (context.performed)
            GameEventManager.Publish(new InputEventsUI.MiddleClickInputEvent());
    }

    public void OnScrollWheel(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
            GameEventManager.Publish(new InputEventsUI.ScrollWheelInputEvent { ScrollDelta = context.ReadValue<Vector2>() });
    }

    public void OnTrackedDevicePosition(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
            GameEventManager.Publish(new InputEventsUI.TrackedDevicePositionEvent { Position = context.ReadValue<Vector3>() });
    }

    public void OnTrackedDeviceOrientation(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
            GameEventManager.Publish(new InputEventsUI.TrackedDeviceOrientationEvent { Rotation = context.ReadValue<Quaternion>() });
    }
}
