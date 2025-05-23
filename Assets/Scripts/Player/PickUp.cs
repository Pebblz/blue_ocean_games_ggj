using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable
{
    public EquipmentPart part;
    public GameObject inventoryItemPrefab;

    public bool CanBeInteractedWith()
    {
        return true;
    }

    public void OnInteract()
    {
        Inventory inventory = (Inventory)FindAnyObjectByType(typeof(Inventory), FindObjectsInactive.Include);
        inventory.AddItemToInventory(part);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
