using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Attack;

[CreateAssetMenu(fileName = "Shooting Channel", menuName = "Channels/Shooting Channel", order = 1)]
public class ShootingChannel : ScriptableObject, IShootingActions
{
 
    public void OnShoot(InputAction.CallbackContext context)
    {

      //  if (context.phase == InputActionPhase.Performed)
       // {
          //  ShootEvent?.Invoke();
       // }
       // if (context.phase == InputActionPhase.Canceled)
       // {
           // ShootCancelledEvent?.Invoke();
       // }
    }
}
