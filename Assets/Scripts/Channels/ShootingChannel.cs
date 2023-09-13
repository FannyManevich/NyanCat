using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Attack;

[CreateAssetMenu(fileName = "Shooting Channel", menuName = "Channels/Shooting Channel", order = 1)]
public class ShootingChannel : ScriptableObject, IShootingActions
{
    bool shootingPressed = false;
    public event Action ShootEvent;
    public event Action ShootCancelledEvent;
    

    private void HandleShootEvent()
    {
         //Instantiate(projectilePrefab, transform.position, transform.rotation);
    }
    private void HandleShootCancelledEvent()
    {

    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        shootingPressed = true;

        if (context.phase == InputActionPhase.Performed)
        {
            ShootEvent?.Invoke();
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            ShootCancelledEvent?.Invoke();
        }
    }
}
