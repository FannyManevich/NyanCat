using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class GameplayInputHandler : MonoBehaviour, PlayerControls.IGameplayActions {
    public event Action<Vector2> MoveEvent;
    public event Action ShootEvent;
    public event Action ShootCancelledEvent;

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveValue = context.ReadValue<Vector2>();
        MoveEvent?.Invoke(moveValue);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                ShootEvent?.Invoke();
                break;
            case InputActionPhase.Canceled:
                ShootCancelledEvent?.Invoke();
                break;
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {

    }
}
