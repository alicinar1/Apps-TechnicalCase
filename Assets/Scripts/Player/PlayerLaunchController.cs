using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerLaunchController : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRB;
    private void Start()
    {
        DragInputData.OnPlayerLaunch += LaunchPlayer;
    }
    private void OnDisable()
    {
        DragInputData.OnPlayerLaunch -= LaunchPlayer;
    }

    private void LaunchPlayer(float lauchPower)
    {
        playerRB.useGravity = true;
        Debug.Log("PlayerLaunch!");
        playerRB.GetComponent<Rigidbody>().AddForce(0, lauchPower / 10, lauchPower / 10, ForceMode.Impulse);
    }
}
