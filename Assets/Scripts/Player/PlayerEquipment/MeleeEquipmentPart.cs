using System.Collections;
using UnityEngine;

public class MeleeEquipmentPart : SustainedEquipment
{

    // DO NOT IMPLEMENT
    public GameObject hitbox; 
    public bool isVisible = true;
    public Transform player;
    public override float sustainTime { get { return 0.2f; } }

    public MeleeEquipmentPart()
    {
        // position of arms in the PART_LOCATION enum
        int location = Random.Range(1, 3);
        partLocation = (PART_LOCATION) location;

    }

    public override void ActionEnd()
    {
        hitbox.GetComponent<MeshRenderer>().enabled = isVisible;
        hitbox.SetActive(false);
    }

    public override void ActionStart()
    {
        hitbox.SetActive(true);        
        timer.reset();
        hitbox.GetComponent<MeshRenderer>().enabled = isVisible;
        timer.startTimer();
    }
}