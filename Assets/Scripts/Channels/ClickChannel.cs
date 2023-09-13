using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Click;

[CreateAssetMenu(fileName = "Click Channel", menuName = "Channels/Click Channel", order = 2)]
public class ClickChannel : ScriptableObject, IButtonsActions
{
    public void OnClick(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
