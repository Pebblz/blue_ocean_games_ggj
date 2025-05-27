using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(PlayerStats))]
public class PlayerEquipment : MonoBehaviour
{
    public Dictionary<PART_LOCATION, EquipmentPart> equipment;
    public PlayerStats stats;
    private AudioManager audioManager;

    [Header("Weapon Hitboxes")]
    public GameObject meleeHitBox;
    public GameObject flamethrowerHitbox;


    private void Awake()
    {
        equipment = new Dictionary<PART_LOCATION, EquipmentPart>();
        equipment.Add(PART_LOCATION.HEAD, new EmptyEquipmentPart());
        equipment.Add(PART_LOCATION.LEFT_ARM, new EmptyEquipmentPart());
        equipment.Add(PART_LOCATION.RIGHT_ARM, new EmptyEquipmentPart());
        equipment.Add(PART_LOCATION.TORSO, new EmptyEquipmentPart());
        equipment.Add(PART_LOCATION.LEGS, new EmptyEquipmentPart());
        stats = GetComponent<PlayerStats>();
        audioManager =  GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    public void Update()
    {
        foreach (KeyValuePair<PART_LOCATION, EquipmentPart> kvp in equipment)
            Debug.Log("Key = {0} + Value = {1}" + kvp.Key + kvp.Value);
    }



    public void equip(PART_LOCATION location, EquipmentPart part)
    {

        EquipmentPart oldEquip;
        equipment.TryGetValue(location, out oldEquip);
        if (oldEquip is not EmptyEquipmentPart)
        {
            unequip(location);
        }

        
            
        part.movement = stats.GetComponent<PlayerMovement>();
        part.body = stats.GetComponent<Rigidbody>();
        part.audioManager = audioManager;
        foreach( KeyValuePair<PLAYER_STATS, int> kvp in part.playerStatChanges){
            stats.addStat(kvp.Key, kvp.Value);
        }


        if(part is SustainedEquipment)
        {
            var g = new GameObject();
            g = Instantiate(g);
            g.name = $"{part.GetType().ToString()} Timer [{part.partLocation.ToString()}]" ;
            g.AddComponent<Timer>();
            var timer = g.GetComponent<Timer>();
            var sus = part as SustainedEquipment;
            timer.onTimedOut = sus.ActionEnd;
            timer.setDuration(sus.sustainTime);
            timer.oneShot = sus.oneShot;
            sus.timer = timer;
            g.transform.parent = stats.gameObject.transform;
            
        }

        if(part is MeleeEquipmentPart)
        {
            
            var melee = part as MeleeEquipmentPart;
            var hitbox = Instantiate(meleeHitBox);
            hitbox.name = $"{part.GetType().ToString()} Hitbox [{part.partLocation.ToString()}]";
            melee.hitbox = hitbox;
            hitbox.transform.parent = stats.gameObject.transform.GetChild(0).transform;
            hitbox.transform.localRotation = Quaternion.identity;

        }

        if(part is FlamethrowerEquipmentPart)
        {
            var flame = part as FlamethrowerEquipmentPart;
            var hitbox = Instantiate(flamethrowerHitbox);
            hitbox.name = $"{part.GetType().ToString()} Hitbox [{part.partLocation.ToString()}]";
            hitbox.transform.position = stats.gameObject.transform.position + stats.gameObject.transform.forward; 
            hitbox.transform.parent = stats.gameObject.transform.GetChild(0).transform;
            hitbox.transform.localRotation = Quaternion.identity;
            flame.hitbox = hitbox;
        }
        //TODO: parent equipment model to player


        equipment[location] = part;

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

        if(part is SustainedEquipment)
        {
            var sus = part as SustainedEquipment;
            Destroy(sus.timer.gameObject);
            
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
