using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    bool shootingPressed = false;
    public event Action ShootEvent;
    public event Action ShootCancelledEvent;
    ShootingChannel shootingChannel;
    private void HandleShootEvent()
    {
        shootingPressed = true;
    }
    private void HandleShootCancelledEvent()
    {
        shootingPressed = false;
    }

}
