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
        Inventory inventory = GameObject.FindGameObjectWithTag("UI").GetComponent<Pause>().inventory.GetComponent<Inventory>();

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
