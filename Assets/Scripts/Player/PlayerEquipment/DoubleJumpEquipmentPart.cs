using System.Collections.Generic;
using UnityEngine;


public class DoubleJumpEquipmentPart : EquipmentPart
{

    public float magnitude = 8f;
    private Vector3 ForceDirection = Vector3.up;
    public DoubleJumpEquipmentPart() : base()
    {

        partLocation = PART_LOCATION.LEGS;

    }

    public override void Action()
    {

        ForceDirection = Vector3.up;
        ForceDirection.x += body.linearVelocity.x;
        ForceDirection.z += body.linearVelocity.z;
        ForceDirection *= magnitude;
        body.AddForce(ForceDirection, ForceMode.Impulse);
    }

}