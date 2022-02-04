using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlyController : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private float flyDrag;
    [SerializeField] private float rollDrag;
    [SerializeField] private float flyAngularDrag;
    [SerializeField] private float rollAngularDrag;

    private bool _isFlying = false;


    private void Start()
    {

    }

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
        //playerRB.AddForceAtPosition(new Vector3(steeringValue / 1000 , - steeringValue / 1000 , 0), torquePoint.position, ForceMode.Impulse);
        playerAnimator.SetFloat("Rotation", steeringValue);
        playerRB.AddForceAtPosition(new Vector3(steeringValue, 0, 0), playerRB.transform.position + Vector3.forward);
        Debug.Log(steeringValue);
    }

    private void Flying()
    {
        if (_isFlying)
        {
            playerRB.AddForce(Vector3.forward * 10);
            return;
        }

        SetPhysicsToFly();
        _isFlying = true;
    }

    private void Rolling()
    {
        if (!_isFlying)
        {
            playerRB.AddForce(Vector3.forward * 10);
            return;
        }
        SetPhysicsToRoll();
        _isFlying = false;
    }

    private void SetPhysicsToFly()
    {
        Physics.gravity = new Vector3(0, -3, 0);
        playerRB.drag = flyDrag;
        playerRB.angularDrag = flyAngularDrag;
    }

    private void SetPhysicsToRoll()
    {
        Physics.gravity = new Vector3(0, -5f, 0);
        playerRB.drag = rollDrag;
        playerRB.angularDrag = rollAngularDrag;
    }
}
