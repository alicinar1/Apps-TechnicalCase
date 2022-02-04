using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerLaunchController : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerRB;
    [SerializeField] private Transform _stickTopPosition;

    private void OnEnable()
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
        _playerRB.useGravity = true;
        Debug.Log("PlayerLaunch!");
        _playerRB.GetComponent<Rigidbody>().AddForce(0, lauchPower / 3, lauchPower, ForceMode.Impulse);
    }
    private void SetPlayerDrag(float drag)
    {
        _playerRB.position = _stickTopPosition.position;
        _playerRB.rotation = _stickTopPosition.rotation;
    }
}
