using UnityEngine;

public class FlameThrowerPickUp : PickUp
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        part = new FlamethrowerEquipmentPart();
        part.partInventoryItem = inventoryItemPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
