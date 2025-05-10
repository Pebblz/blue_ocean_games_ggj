
using System.Collections;
using UnityEngine;

public class MeleeEquipmentPart : SustainedEquipment
{

    // DO NOT IMPLEMENT
    public GameObject hitbox; 
    public bool isVisible = false;
    public override float sustainTime { get { return 0.2f; } }

    public MeleeEquipmentPart()
    {
        // position of arms in the PART_LOCATION enum
        int location = Random.Range(1, 3);
        partLocation = (PART_LOCATION) location;

    }

    public override void ActionEnd()
    {
        hitbox.SetActive(true);
        hitbox.GetComponent<MeshRenderer>().enabled = isVisible;
    }

    public override void ActionStart()
    {
        timer.reset();
        hitbox.SetActive(true);
        hitbox.GetComponent<MeshRenderer>().enabled = isVisible;
        timer.startTimer();
    }
}