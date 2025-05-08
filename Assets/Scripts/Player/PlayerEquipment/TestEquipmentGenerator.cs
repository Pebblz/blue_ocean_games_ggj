using UnityEngine;

public class TestEquipmentGenerator : MonoBehaviour
{
    private void Start()
    {
        EquipmentPart[] parts = new EquipmentPart[10];
        for (int i = 0; i < 10; i++)
        {
            var part = EquipmentPartGenerator.generate();
            Debug.Log($"{i + 1},  Part: ${part.ToString()}");
            parts[i] = part;
        }

        PlayerEquipment equipmentManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEquipment>();

        foreach(EquipmentPart p in parts)
        {
            equipmentManager.equip(p.partLocation, p);
        }

        Debug.Log(equipmentManager.ToString());
    }
}
