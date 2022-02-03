using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlyController : MonoBehaviour
{
    [SerializeField] private float rollingForce = 10f;
    private Rigidbody playerRB;
    [SerializeField] private float flyMass;
    [SerializeField] private float rollMass;
    [SerializeField] private float flyDrag;
    [SerializeField] private float rollDrag;
    [SerializeField] private float flyAngularDrag;
    [SerializeField] private float rollAngularDrag;


    private void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody>();

        TapHoldInputData.OnHoldStart += Flying;
        TapHoldInputData.OnHoldEnd += Rolling;
    }
    private void Flying()
    {
        SetPhysicsToFly();
        playerRB.rotation = Quaternion.Lerp(playerRB.rotation, Quaternion.Euler(90, 0, 0), 1);
        playerRB.angularVelocity = Vector3.zero;
    }

    private void Rolling()
    {
        SetPhysicsToRoll();
        playerRB.AddRelativeTorque(new Vector3(rollingForce, 0, 0), ForceMode.Force);
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
