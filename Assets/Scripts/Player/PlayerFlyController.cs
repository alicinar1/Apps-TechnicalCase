using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlyController : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerRB;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private float _flyDrag;
    [SerializeField] private float _rollDrag;
    [SerializeField] private float _flyAngularDrag;
    [SerializeField] private float _rollAngularDrag;

    private bool _isFlying = false;

    private void OnEnable()
    {
        TapHoldInputData.OnHoldStart += Flying;
        TapHoldInputData.OnHoldEnd += Rolling;
        SteeringInputData.OnHoldStart += Steering;
    }

    private void OnDisable()
    {
        TapHoldInputData.OnHoldStart -= Flying;
        TapHoldInputData.OnHoldEnd -= Rolling;
        SteeringInputData.OnHoldStart -= Steering;
    }

    private void Steering(float steeringValue)
    {
        _playerAnimator.SetFloat("Rotation", steeringValue);
        _playerRB.AddForceAtPosition(new Vector3(steeringValue, 0, 0), _playerRB.transform.position + Vector3.forward);
    }

    private void Flying()
    {
        if (_isFlying)
        {
            _playerRB.AddForce(Vector3.forward * 10);
            return;
        }

        SetPhysicsToFly();
        _isFlying = true;
    }

    private void Rolling()
    {
        if (!_isFlying)
        {
            _playerRB.AddForce(Vector3.forward * 10);
            return;
        }
        SetPhysicsToRoll();
        _isFlying = false;
    }

    private void SetPhysicsToFly()
    {
        Physics.gravity = new Vector3(0, -3, 0);
        _playerRB.drag = _flyDrag;
        _playerRB.angularDrag = _flyAngularDrag;
    }

    private void SetPhysicsToRoll()
    {
        Physics.gravity = new Vector3(0, -5f, 0);
        _playerRB.drag = _rollDrag;
        _playerRB.angularDrag = _rollAngularDrag;
    }
}
