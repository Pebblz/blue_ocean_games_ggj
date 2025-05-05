using System.Collections.Generic;
using UnityEngine;



public enum PART_LOCATION
{
    HEAD,
    LEFT_ARM,
    RIGHT_ARM,
    TORSO,
    WAIST,
    LEGS
}
public abstract class EquipmentPart 
{
    protected PlayerMovement movement;
    protected PART_LOCATION partLocation;
    protected PlayerEquipment playerEquipment;
    protected GameObject partObject;
    public Dictionary<PLAYER_STATS, int> playerStatChanges;


    public EquipmentPart()
    {
        playerStatChanges = new Dictionary<PLAYER_STATS, int>();
    }

    public EquipmentPart(PlayerMovement movement, PART_LOCATION partLocation, GameObject partObject)
    {
        this.playerStatChanges = new Dictionary<PLAYER_STATS, int>();
        this.movement = movement;
        this.partLocation = partLocation;
        this.partObject = partObject;

    }

    public void addStatAlteration(PLAYER_STATS stat, int amount)
    {
        playerStatChanges.Add(stat, amount);
    }
   
    public abstract void Action();

    


}



