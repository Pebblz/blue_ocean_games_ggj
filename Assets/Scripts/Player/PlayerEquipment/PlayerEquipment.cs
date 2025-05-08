using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerStats))]
public class PlayerEquipment : MonoBehaviour
{
    public Dictionary<PART_LOCATION, EquipmentPart> equipment;
    public PlayerStats stats;


    private void Awake()
    {
        equipment = new Dictionary<PART_LOCATION, EquipmentPart>();
        equipment.Add(PART_LOCATION.HEAD, new EmptyEquipmentPart());
        equipment.Add(PART_LOCATION.LEFT_ARM, new EmptyEquipmentPart());
        equipment.Add(PART_LOCATION.RIGHT_ARM, new EmptyEquipmentPart());
        equipment.Add(PART_LOCATION.TORSO, new EmptyEquipmentPart());
        equipment.Add(PART_LOCATION.WAIST, new EmptyEquipmentPart());
        equipment.Add(PART_LOCATION.LEGS, new EmptyEquipmentPart());
        stats = GetComponent<PlayerStats>();
    }



    public void equip(PART_LOCATION location, EquipmentPart part)
    {

        EquipmentPart oldEquip;
        equipment.TryGetValue(location, out oldEquip);
        if (oldEquip is not EmptyEquipmentPart)
        {
            unequip(location);
        }

        equipment[location] = part;
        foreach( KeyValuePair<PLAYER_STATS, int> kvp in part.playerStatChanges){
            stats.addStat(kvp.Key, kvp.Value);
        }

        //TODO: parent equipment model to player

        
    }

    public void unequip(PART_LOCATION location)
    {
        if (equipment[location] is EmptyEquipmentPart)
            return; 

        EquipmentPart part = equipment[location];
        foreach (KeyValuePair<PLAYER_STATS, int> kvp in part.playerStatChanges)
        {
            stats.removeStat(kvp.Key, kvp.Value);
        }

        equipment[location] = new EmptyEquipmentPart();

        //TODO: unparent equipment model to player

    }

    public override string ToString()
    {
        string output = "";
        foreach(var equip in equipment)
        {
            output += equip.ToString();
        }
        return output;
    }

}
