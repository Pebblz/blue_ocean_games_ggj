using System.Collections.Generic;
using UnityEngine;


public class DoubleJumpEquipmentPart : EquipmentPart
{
    private Rigidbody body;

    private Vector3 Force;
    public float forceCoefficent = 3;
    public DoubleJumpEquipmentPart(PlayerMovement movement) : base()
    {

        partLocation = PART_LOCATION.LEGS;
        this.movement = movement;
        body = movement.GetComponent<Rigidbody>();

    }

    public override void Action()
    {
        Force = Vector3.up;
        Force.x += body.linearVelocity.x;
        Force.z += body.linearVelocity.z;
        Force *= forceCoefficent;
        body.AddForce(Force, ForceMode.Impulse);
    }

}