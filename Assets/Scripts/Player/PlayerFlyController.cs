using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlyController : MonoBehaviour
{
    [SerializeField] private float rollingForce = 10f;
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private Transform torquePoint;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private float flyMass;
    [SerializeField] private float rollMass;
    [SerializeField] private float flyDrag;
    [SerializeField] private float rollDrag;
    [SerializeField] private float flyAngularDrag;
    [SerializeField] private float rollAngularDrag;

    private bool _isFlying = false;

    private float steering;


    private void Start()
    {
        TapHoldInputData.OnHoldStart += Flying;
        TapHoldInputData.OnHoldEnd += Rolling;
        SteeringInputData.OnHoldStart += Steering;
    }

    private void Steering(float steeringValue)
    {
        //playerAnimator.enabled = false;
        //playerBody.rotation = Quaternion.Euler(new Vector3(0, steeringValue / 100, 0));
        //playerTransform.rotation = Quaternion.Euler(new Vector3(0, steeringValue, 0));
        //playerAnimator.SetFloat("Rotation", steeringValue / 10);
        playerRB.AddForceAtPosition(new Vector3(steeringValue / 1000 , - steeringValue / 1000 , 0), torquePoint.position, ForceMode.Impulse);
        Debug.Log(steeringValue);
        //playerAnimator.enabled = true;
    }

    private void Flying()
    {
        //if (_isFlying){ return; }

        SetPhysicsToFly();
        //playerRB.rotation = Quaternion.Euler(90, 0, 0);
        //playerRB.angularVelocity = Vector3.zero;
        _isFlying = true;
    }

    private void Rolling()
    {
        if (!_isFlying)
        {
            return;
        }
        SetPhysicsToRoll();
        //playerRB.AddRelativeTorque(new Vector3(rollingForce, 0, 0), ForceMode.Force);
        _isFlying = false;
    }

    private void SetPhysicsToFly()
    {
        Physics.gravity = new Vector3(0, -3, 0);
        //playerRB.mass = flyMass;
        playerRB.drag = flyDrag;
        playerRB.angularDrag = flyAngularDrag;
    }

    private void SetPhysicsToRoll()
    {
        Physics.gravity = new Vector3(0, -9.81f, 0);
        //playerRB.mass = rollMass;
        playerRB.drag = rollDrag;
        playerRB.angularDrag = rollAngularDrag;
    }
}
