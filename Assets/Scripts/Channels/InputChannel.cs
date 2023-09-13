using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Movement;

[CreateAssetMenu(fileName ="Input Channel", menuName = "Channels/Input Channel", order = 0 )]
public class InputChannel : ScriptableObject, IPlayerActions
{
    Movement move;   
    public event Action<Vector2> MoveEvent;
      
    private void OnEnable()
    {
        if (move == null)
        {
            move = new Movement();
            move.Player.SetCallbacks(this);
            move.Enable();
        }
    }

    private void OnDisable()
    {
        move.Disable();
    }

    private void Awake()
    {
      //  gameplayInputHandler = new GameplayInputHandler();
      //  gameplayInputHandler.MoveEvent += HandleMoveEvent;
       // gameplayInputHandler.ShootEvent += HandleShootEvent;
      //  gameplayInputHandler.ShootCancelledEvent += HandleShootCancelledEvent;
    }

    private void OnDestroy()
    {
     //   gameplayInputHandler.MoveEvent -= HandleMoveEvent;
       // gameplayInputHandler.ShootEvent -= HandleShootEvent;
       // gameplayInputHandler.ShootCancelledEvent -= HandleShootCancelledEvent;
    }

    private void HandleMoveEvent(Vector2 moveValue)
    {
       // Rigidbody2D rb = GetComponent<Rigidbody2D>();
       // rb.velocity = moveValue * 10;
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveValue = context.ReadValue<Vector2>();
        MoveEvent?.Invoke(moveValue);
    }

  
}