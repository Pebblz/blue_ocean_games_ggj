using System;
using UnityEngine;

public class TestEquipmentGenerator : MonoBehaviour
{

    public enum Tests { 
    DoubleJump,
    HoverBoots,
    RandomEquipmentGen}

    public Tests testToRun = Tests.DoubleJump;
    private void Start()
    {
        switch (testToRun)
        {
            case Tests.DoubleJump:
                testDoubleJump();
                break;
            case Tests.HoverBoots:
                testHoverBoots();
                break;
            case Tests.RandomEquipmentGen:
                testEquipmentGeneratorAndEquip();
                break;
        }
    }
    public void testHoverBoots()
    {
        PlayerEquipment equipmentManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEquipment>();
        EquipmentPart part = new HoverBoots();
        equipmentManager.equip(part.partLocation, part);

    }

    public void testDoubleJump()
    {
        PlayerEquipment equipmentManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEquipment>();

        EquipmentPart part = new DoubleJumpEquipmentPart();
        part.movement = equipmentManager.gameObject.GetComponent<PlayerMovement>();
        equipmentManager.equip(part.partLocation,part);

    }

    public void testEquipmentGeneratorAndEquip()
    {
        EquipmentPart[] parts = new EquipmentPart[10];
        for (int i = 0; i < 10; i++)
        {
            var part = EquipmentPartGenerator.generate();
            Debug.Log($"{i + 1},  Part: ${part.ToString()}");
            parts[i] = part;
        }

        PlayerEquipment equipmentManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEquipment>();

        foreach (EquipmentPart p in parts)
        {
            equipmentManager.equip(p.partLocation, p);
        }

        Debug.Log(equipmentManager.ToString());
    }
}
