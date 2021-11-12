using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInput _PlayerInput;
    public UnityEvent _OnRightPressedEvent = new UnityEvent();
    public UnityEvent _OnLeftPressedEvent = new UnityEvent();
    public UnityEvent _OnRightCanceledEvent = new UnityEvent();
    public UnityEvent _OnLeftCanceledEvent = new UnityEvent();
    public UnityEvent _InteractionStartedEvent = new UnityEvent();
    public UnityEvent _InteractionCanceledEvent = new UnityEvent();
    public UnityEvent _EscapeStartedEvent = new UnityEvent();
    public UnityEvent _EscapeCanceledEvent = new UnityEvent();
    InputAction _onRightPressed;
    InputAction _onLeftPressed;
    InputAction _onInteractionPressed;
    InputAction _onEscapePressed;
    private void Awake()
    {
        Init();
    }
    public void Init()
    {
        _onRightPressed = _PlayerInput.actions["OnRightPressed"];
        _onLeftPressed = _PlayerInput.actions["OnLeftPressed"];
        _onInteractionPressed = _PlayerInput.actions["Interaction"];
        _onEscapePressed = _PlayerInput.actions["Escape"];
        _onRightPressed.started += OnRightPressedStarted;
        _onRightPressed.canceled += OnRightPressedCanceled;
        _onLeftPressed.started += OnLeftPressedStarted;
        _onLeftPressed.canceled += OnLeftPressedCanceled;
        _onInteractionPressed.started += OnInteractionStarted;
        _onInteractionPressed.canceled += OnInteractionCanceled;
        _onEscapePressed.started += OnEscapeStarted;
        _onEscapePressed.canceled += OnEscapeCanceld;

    }
    void OnRightPressedStarted(InputAction.CallbackContext context)
    {
        _OnRightPressedEvent.Invoke();
    }
    void OnRightPressedCanceled(InputAction.CallbackContext context)
    {
        _OnRightCanceledEvent.Invoke();
    }
    void OnLeftPressedStarted(InputAction.CallbackContext context)
    {
        _OnLeftPressedEvent.Invoke();
    }
    void OnLeftPressedCanceled(InputAction.CallbackContext context)
    {
        _OnLeftCanceledEvent.Invoke();
    }
    void OnInteractionStarted(InputAction.CallbackContext context)
    {
        _InteractionStartedEvent.Invoke();
    }
    void OnInteractionCanceled(InputAction.CallbackContext context)
    {
        _InteractionCanceledEvent.Invoke();
    }
    void OnEscapeStarted(InputAction.CallbackContext context)
    {
        _EscapeStartedEvent.Invoke();
    }
    void OnEscapeCanceld(InputAction.CallbackContext context)
    {
        _EscapeCanceledEvent.Invoke();
    }
    public void DisableBallMove()
    {
        _onRightPressed.Disable();
        _onLeftPressed.Disable();
    }
    public void EnableBallMove()
    {
        _onRightPressed.Enable();
        _onLeftPressed.Enable();
    }
    public void Clear()
    {

    }
}
