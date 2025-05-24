using UnityEngine;
using UnityEngine.Rendering;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Slot[] inventorySlots = new Slot[12];
    [SerializeField] private Slot[] characterSlots = new Slot[5];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].SetEmpty(true);
            inventorySlots[i].SetSlotIndex(i);
            inventorySlots[i].setEquipmentPart(new EmptyEquipmentPart());
        }

        for (int i = 0; i < characterSlots.Length; i++)
        {
            characterSlots[i].SetEmpty(true);
            characterSlots[i].SetSlotIndex(i);
            characterSlots[i].setEquipmentPart(new EmptyEquipmentPart());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItemToInventory(EquipmentPart part)
    {
        for(int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].IsEmpty())
            {
                inventorySlots[i].setEquipmentPart(part);
                inventorySlots[i].SetEmpty(false);
                GameObject inventoryItem = Instantiate(inventorySlots[i].GetEquipmentPart().partInventoryItem, inventorySlots[i].transform);
                break;
            }
        }
    }
}
