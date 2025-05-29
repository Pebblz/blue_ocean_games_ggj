using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : Slot, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

            if (draggableItem.parentAfterDrag.TryGetComponent<CharacterSlot>(out CharacterSlot cs))
            {
                PlayerEquipment equipmentManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEquipment>();
                EquipmentPart part = draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().GetEquipmentPart();
                switch (draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().bodyLocation)
                {
                    case CharacterSlot.BodyLocation.Head:
                        equipmentManager.unequip(PART_LOCATION.HEAD);
                        break;
                    case CharacterSlot.BodyLocation.Body:
                        equipmentManager.unequip(PART_LOCATION.TORSO);
                        break;
                    case CharacterSlot.BodyLocation.LeftArm:
                        equipmentManager.unequip(PART_LOCATION.LEFT_ARM);
                        break;
                    case CharacterSlot.BodyLocation.RightArm:
                        equipmentManager.unequip(PART_LOCATION.RIGHT_ARM);
                        break;
                    case CharacterSlot.BodyLocation.Legs:
                        equipmentManager.unequip(PART_LOCATION.LEGS);
                        break;
                }
                draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(true);
                draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(new EmptyEquipmentPart());
                draggableItem.parentAfterDrag = transform;
                draggableItem.parentAfterDrag.GetComponent<InventorySlot>().SetEmpty(false);
                draggableItem.parentAfterDrag.GetComponent<InventorySlot>().setEquipmentPart(part);

            }
            else
            {
                EquipmentPart part = draggableItem.parentAfterDrag.GetComponent<InventorySlot>().GetEquipmentPart();

                draggableItem.parentAfterDrag.GetComponent<InventorySlot>().SetEmpty(true);
                draggableItem.parentAfterDrag.GetComponent<InventorySlot>().setEquipmentPart(new EmptyEquipmentPart());
                draggableItem.parentAfterDrag = transform;
                draggableItem.parentAfterDrag.GetComponent<InventorySlot>().SetEmpty(false);
                draggableItem.parentAfterDrag.GetComponent<InventorySlot>().setEquipmentPart(part);
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
