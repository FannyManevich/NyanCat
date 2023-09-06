using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

  //private MainCamera mainCamera;

    private void Awake()
    {
    //  mainCamera = Camera.main;

    }

    public void OnClick(InputAction.CallbackContext context)
    {
      //if (!context.started) return;

      //var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
    //  if (!rayHit.collider) return

      //Debug.Log(rayHit.collider.gameObject.name);

    }
}
