using System.Collections.Generic;
using UnityEngine;



public class HoverBoots : SustainedEquipment
{

    public HoverBoots() : base()
    {
        partLocation = PART_LOCATION.LEGS;
    }

    public override void ActionEnd()
    {
        body.useGravity = true;
        body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    public override void ActionStart()
    {
        timer.reset();
        body.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        body.useGravity = false;
        timer.startTimer();
    }
}