using UnityEngine;

public abstract class SustainedEquipment : EquipmentPart
{

    public Timer timer;

    public virtual float sustainTime { get { return 3f; } }
    public bool oneShot = true;

    // DO NOT IMPLEMENT
    public override void Action()
    {
        throw new System.NotImplementedException();
    }

    public abstract void ActionStart();
    public abstract void ActionEnd();   

    
}
