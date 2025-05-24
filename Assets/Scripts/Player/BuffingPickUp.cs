using UnityEngine;

public class BuffingPickUp : PickUp
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        part = new BuffingEquipmentPart();
        part.partInventoryItem = inventoryItemPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
