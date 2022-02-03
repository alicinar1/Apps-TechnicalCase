using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerLaunchController : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private Transform stickTopPosition;
    private void Start()
    {
        DragInputData.OnPlayerLaunch += LaunchPlayer;
        DragInputData.OnPlayerDrag += SetPlayerDrag;
    }
    private void OnDisable()
    {
        DragInputData.OnPlayerLaunch -= LaunchPlayer;
        DragInputData.OnPlayerDrag -= SetPlayerDrag;
    }

    private void LaunchPlayer(float lauchPower)
    {
        playerRB.useGravity = true;
        Debug.Log("PlayerLaunch!");
        playerRB.GetComponent<Rigidbody>().AddForce(0, lauchPower / 3, lauchPower, ForceMode.Impulse);
    }
    private void SetPlayerDrag(float drag)
    {
        playerRB.position = stickTopPosition.position;
        playerRB.rotation = stickTopPosition.rotation;
    }
}
