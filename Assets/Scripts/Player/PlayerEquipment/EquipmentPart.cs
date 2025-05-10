using System.Collections.Generic;
using UnityEngine;



public enum PART_LOCATION
{
    HEAD,
    LEFT_ARM,
    RIGHT_ARM,
    TORSO,
    LEGS
}
public abstract class EquipmentPart 
{
    public PlayerMovement movement;
    public PART_LOCATION partLocation;
    protected GameObject partObject;
    public Dictionary<PLAYER_STATS, int> playerStatChanges;
    public Rigidbody body;


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
        if (playerStatChanges.ContainsKey(stat))
        {
            playerStatChanges[stat] += amount;
        }
        else { 
            playerStatChanges.Add(stat, amount);
        }
    }
   
    public abstract void Action();

    public override string ToString()
    {
        string output = string.Empty;
        output += partLocation.ToString();
        output += " ";
        foreach (var statChange in playerStatChanges)
        {

            output += $"{statChange.Key.ToString()}: {statChange.Value.ToString()} ";
        }
        return output;
    }




}



