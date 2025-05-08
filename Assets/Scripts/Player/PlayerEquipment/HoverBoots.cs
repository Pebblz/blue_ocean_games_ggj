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
       body.linearVelocity = new Vector3(body.linearVelocity.x, body.linearVelocity.y, 0);
    }

    public override void ActionStart()
    {
        timer.reset();
        body.useGravity = false;
        timer.startTimer();
    }
}