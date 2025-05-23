using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterSlot : Slot, IDropHandler
{
    public enum BodyLocation
    {
        Head,
        Body,
        LeftArm,
        RightArm,
        Legs
    }

    public BodyLocation bodyLocation;
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

            EquipmentPart part = draggableItem.parentAfterDrag.GetComponent<InventorySlot>().GetEquipmentPart();


            draggableItem.parentAfterDrag = transform;

            //add code for equiping the part to the character in game
            PlayerEquipment equipmentManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEquipment>();

            switch (bodyLocation)
            {
                case BodyLocation.Head:
                    part.partLocation = PART_LOCATION.HEAD;
                    equipmentManager.equip(part.partLocation, part);
                    break;
                case BodyLocation.Body:
                    part.partLocation = PART_LOCATION.TORSO;
                    equipmentManager.equip(part.partLocation, part);
                    break;
                case BodyLocation.LeftArm:
                    part.partLocation = PART_LOCATION.LEFT_ARM;
                    equipmentManager.equip(part.partLocation, part);
                    break;
                case BodyLocation.RightArm:
                    part.partLocation = PART_LOCATION.RIGHT_ARM;
                    equipmentManager.equip(part.partLocation, part);
                    break;
                case BodyLocation.Legs:
                    part.partLocation = PART_LOCATION.LEGS;
                    equipmentManager.equip(part.partLocation, part);
                    break;

            }
        } else
        {
            GameObject droppedItem = eventData.pointerDrag;
            GameObject currentItem = transform.GetChild(0).gameObject;

            DraggableItem newItem = droppedItem.GetComponent<DraggableItem>();
            DraggableItem oldItem = currentItem.GetComponent<DraggableItem>();

            oldItem.transform.SetParent(newItem.parentAfterDrag);

            newItem.parentAfterDrag = transform;
            
            PlayerEquipment equipmentManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEquipment>();
            EquipmentPart part = new FlamethrowerEquipmentPart();

            switch (bodyLocation)
            {
                case BodyLocation.Head:                  
                    part.partLocation = PART_LOCATION.HEAD;
                    equipmentManager.equip(part.partLocation, part);
                    break;
                case BodyLocation.Body:
                    part.partLocation = PART_LOCATION.TORSO;
                    equipmentManager.equip(part.partLocation, part);
                    break; 
                case BodyLocation.LeftArm:
                    part.partLocation = PART_LOCATION.LEFT_ARM;
                    equipmentManager.equip(part.partLocation, part);
                    break;
                case BodyLocation.RightArm:
                    part.partLocation = PART_LOCATION.RIGHT_ARM;
                    equipmentManager.equip(part.partLocation, part);
                    break;
                case BodyLocation.Legs:
                    part.partLocation = PART_LOCATION.LEGS;
                    equipmentManager.equip(part.partLocation, part);
                    break;

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
