using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputChannel : MonoBehaviour {
    private PlayerControls playerControls;
    private GameplayInputHandler gameplayInputHandler;

    
    private void OnEnable()
    {
       if (playerControls == null)
    {
        playerControls = new PlayerControls();
     // playerControls.Gameplay.SetCallbacks(this); 
      //playerControls.Enable();
    }
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Awake()
    {
        gameplayInputHandler = new GameplayInputHandler();
        gameplayInputHandler.MoveEvent += HandleMoveEvent;
        gameplayInputHandler.ShootEvent += HandleShootEvent;
        gameplayInputHandler.ShootCancelledEvent += HandleShootCancelledEvent;
    }

    private void OnDestroy()
    {
        gameplayInputHandler.MoveEvent -= HandleMoveEvent;
        gameplayInputHandler.ShootEvent -= HandleShootEvent;
        gameplayInputHandler.ShootCancelledEvent -= HandleShootCancelledEvent;
    }

    private void HandleMoveEvent(Vector2 moveValue)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = moveValue * 10;
    }

    private void HandleShootEvent()
    {
    //  Instantiate(projectilePrefab, transform.position, transform.rotation);
    }
    private void HandleShootCancelledEvent()
    {
        
    }
}