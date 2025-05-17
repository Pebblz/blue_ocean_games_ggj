using System.Collections;
using UnityEngine;

public class FlamethrowerEquipmentPart : SustainedEquipment
{

    // DO NOT IMPLEMENT
    public GameObject hitbox;
    public bool isVisible = false;
    public ParticleSystem flames;
    public override float sustainTime { get { return 4f; } }

    public FlamethrowerEquipmentPart()
    {
        // position of arms in the PART_LOCATION enum
        int location = Random.Range(1, 3);
        partLocation = (PART_LOCATION)location;

    }

    public override void ActionEnd()
    {
        hitbox.GetComponentInChildren<MeshRenderer>().enabled = isVisible;
        flames.Stop();
        hitbox.SetActive(false);
    }

    public override void ActionStart()
    {
        hitbox.SetActive(true);
        if(flames is null)
        {
            flames = hitbox.GetComponentInChildren<ParticleSystem>();
        }
        timer.reset();
        flames.Play();
        hitbox.GetComponentInChildren<MeshRenderer>().enabled = isVisible;
        timer.startTimer();
    }
}