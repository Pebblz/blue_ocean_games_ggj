using System.Collections.Generic;
using UnityEngine;



public class HoverBoots : SustainedEquipment
{

    public override float sustainTime { get { return 2f; } }
    public HoverBoots() : base()
    {
        partLocation = PART_LOCATION.LEGS;
    }

    public override void ActionEnd()
    {
        body.useGravity = true;
    }

    public override void ActionStart()
    {
        timer.reset();
        body.useGravity = false;
        timer.startTimer();
    }
}