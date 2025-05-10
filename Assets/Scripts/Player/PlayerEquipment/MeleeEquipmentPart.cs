
using UnityEngine;

public class MeleeEquipmentPart : EquipmentPart
{

    // DO NOT IMPLEMENT
    public GameObject hitbox; 
    public bool isVisible = false;
    public float activeHitboxFrames = 1f;
    
    public override void Action()
    {
       hitbox.GetComponent<MeshRenderer>().enabled = isVisible;
    }

}