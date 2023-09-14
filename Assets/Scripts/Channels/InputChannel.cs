using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Movement;

[CreateAssetMenu(fileName ="Input Channel", menuName = "Channels/Input Channel", order = 0 )]
public class InputChannel : ScriptableObject, IPlayerActions
{
    Movement move;
    Movement click;
    public event Action<Vector2> MoveEvent;
    
    public event Action ClickEvent;
    public event Action ClickCanceledEvent;

    private void OnEnable()
    {
        if (move == null)
        {
            move = new Movement();
            move.Player.SetCallbacks(this);
            move.Enable();
        }
        if (click == null)
        {
            click = new Movement();
            click.Player.SetCallbacks(this);
            click.Enable();
        }
    }

    private void OnDisable()
    {
        move.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log(context.phase);   
        Vector2 moveValue = context.ReadValue<Vector2>();
        MoveEvent?.Invoke(moveValue);
    }

    public void EnablePlayer()
    {
        move.Player.Enable();
        click.Player.Disable();
    }

    public void EnableMenu()
    {
        click.Player.Enable();
        move.Player.Disable();
    }
    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            ClickEvent?.Invoke();
            Debug.Log("Mouse Click Detected");
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            ClickCanceledEvent?.Invoke();
            Debug.Log("Mouse Click Canceled");

        }
    }
}