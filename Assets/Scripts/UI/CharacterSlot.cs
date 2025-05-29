using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;

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

            if (draggableItem.parentAfterDrag.TryGetComponent<CharacterSlot>(out CharacterSlot cs))
            {
                EquipmentPart part = draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().GetEquipmentPart();
                PlayerEquipment equipmentManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEquipment>();

                //switch (draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().bodyLocation)
                //{
                //    case BodyLocation.Head:
                //        equipmentManager.unequip(part.partLocation);
                //        break;
                //    case BodyLocation.Body:
                //        equipmentManager.unequip(part.partLocation);
                //        break;
                //    case BodyLocation.LeftArm:
                //        equipmentManager.unequip(part.partLocation);
                //        break;
                //    case BodyLocation.RightArm:
                //        equipmentManager.unequip(part.partLocation);
                //        break;
                //    case BodyLocation.Legs:
                //        equipmentManager.unequip(part.partLocation);
                //        break;
                //}

                switch (bodyLocation)
                {
                    case BodyLocation.Head:
                        if (part is FlamethrowerEquipmentPart)
                        {
                            break;
                        }
                        else if (part is MeleeEquipmentPart)
                        {
                            break;
                        }
                        else if (part is HoverBoots)
                        {
                            break;
                        }
                        else if (part is DoubleJumpEquipmentPart)
                        {
                            break;
                        }
                        break;
                    case BodyLocation.Body:
                        if (part is FlamethrowerEquipmentPart)
                        {
                            break;
                        }
                        else if (part is MeleeEquipmentPart)
                        {
                            break;
                        }
                        else if (part is HoverBoots)
                        {
                            break;
                        }
                        else if (part is DoubleJumpEquipmentPart)
                        {
                            break;
                        }
                        break;
                    case BodyLocation.LeftArm:
                        if (part is FlamethrowerEquipmentPart)
                        {

                            FlamethrowerEquipmentPart flamethrowerEquipmentPart = new FlamethrowerEquipmentPart();
                            flamethrowerEquipmentPart.partLocation = PART_LOCATION.LEFT_ARM;
                            equipmentManager.equip(PART_LOCATION.LEFT_ARM, flamethrowerEquipmentPart);
                            equipmentManager.unequip(part.partLocation);

                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(true);
                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(new EmptyEquipmentPart());
                            draggableItem.parentAfterDrag = transform;
                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(false);
                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(part);
                        }
                        else if (part is MeleeEquipmentPart)
                        {
                            MeleeEquipmentPart meleeEquipmentPart = new MeleeEquipmentPart();
                            meleeEquipmentPart.partLocation = PART_LOCATION.LEFT_ARM;
                            equipmentManager.equip(PART_LOCATION.LEFT_ARM, meleeEquipmentPart);
                            equipmentManager.unequip(part.partLocation);

                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(true);
                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(new EmptyEquipmentPart());
                            draggableItem.parentAfterDrag = transform;
                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(false);
                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(part);
                        }
                        else if (part is HoverBoots)
                        {
                            break;
                        }
                        else if (part is DoubleJumpEquipmentPart)
                        {
                            break;
                        }
                        break;
                    case BodyLocation.RightArm:
                        if (part is FlamethrowerEquipmentPart)
                        {
                            FlamethrowerEquipmentPart flamethrowerEquipmentPart = new FlamethrowerEquipmentPart();
                            flamethrowerEquipmentPart.partLocation = PART_LOCATION.RIGHT_ARM;
                            equipmentManager.equip(PART_LOCATION.RIGHT_ARM, flamethrowerEquipmentPart);
                            equipmentManager.unequip(part.partLocation);

                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(true);
                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(new EmptyEquipmentPart());
                            draggableItem.parentAfterDrag = transform;
                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(false);
                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(part);
                        }
                        else if (part is MeleeEquipmentPart)
                        {
                            MeleeEquipmentPart meleeEquipmentPart = new MeleeEquipmentPart();
                            meleeEquipmentPart.partLocation = PART_LOCATION.RIGHT_ARM;
                            equipmentManager.equip(PART_LOCATION.RIGHT_ARM, meleeEquipmentPart);
                            equipmentManager.unequip(part.partLocation);


                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(true);
                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(new EmptyEquipmentPart());
                            draggableItem.parentAfterDrag = transform;
                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(false);
                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(part);
                        } else if (part is HoverBoots)
                        {
                            break;
                        } else if (part is DoubleJumpEquipmentPart)
                        {
                            break;
                        }
                        break;
                    case BodyLocation.Legs:
                        if (part is FlamethrowerEquipmentPart)
                        {
                            break;
                        }
                        else if (part is MeleeEquipmentPart)
                        {
                            break;
                        }
                        else if (part is HoverBoots)
                        {
                            HoverBoots hoverBoots = new HoverBoots();
                            hoverBoots.partLocation = PART_LOCATION.LEGS;
                            equipmentManager.equip(PART_LOCATION.LEGS, hoverBoots);
                            equipmentManager.unequip(part.partLocation);

                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(true);
                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(new EmptyEquipmentPart());
                            draggableItem.parentAfterDrag = transform;
                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(false);
                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(part);
                            break;
                        }
                        else if (part is DoubleJumpEquipmentPart)
                        {
                            DoubleJumpEquipmentPart doubleJumpEquipmentPart = new DoubleJumpEquipmentPart();
                            doubleJumpEquipmentPart.partLocation = PART_LOCATION.LEGS;
                            equipmentManager.equip(PART_LOCATION.LEGS, doubleJumpEquipmentPart);
                            equipmentManager.unequip(part.partLocation);

                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(true);
                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(new EmptyEquipmentPart());
                            draggableItem.parentAfterDrag = transform;
                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(false);
                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(part);
                            break;
                        }
                        break;
                }
            }
            else
            {
                PlayerEquipment equipmentManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEquipment>();
                EquipmentPart part =  draggableItem.parentAfterDrag.GetComponent<InventorySlot>().GetEquipmentPart();

                switch (bodyLocation)
                {
                    case BodyLocation.Head:
                        if(part is FlamethrowerEquipmentPart)
                        {
                            break;
                        } else if (part is MeleeEquipmentPart)
                        {
                            break;
                        } else if (part is HoverBoots)
                        {
                            break;
                        } else if (part is DoubleJumpEquipmentPart)
                        {
                            break;
                        }
                        break;
                    case BodyLocation.Body:
                        if (part is FlamethrowerEquipmentPart)
                        {
                            break;
                        }
                        else if (part is MeleeEquipmentPart)
                        {
                            break;
                        }
                        else if (part is HoverBoots)
                        {
                            break;
                        }
                        else if (part is DoubleJumpEquipmentPart)
                        {
                            break;
                        }
                        break;
                    case BodyLocation.LeftArm:
                        if (part is FlamethrowerEquipmentPart)
                        {
                            FlamethrowerEquipmentPart flamethrowerEquipmentPart = new FlamethrowerEquipmentPart();
                            flamethrowerEquipmentPart.partLocation = PART_LOCATION.LEFT_ARM;
                            equipmentManager.equip(PART_LOCATION.LEFT_ARM, flamethrowerEquipmentPart);

                            draggableItem.parentAfterDrag.GetComponent<InventorySlot>().SetEmpty(true);
                            draggableItem.parentAfterDrag.GetComponent<InventorySlot>().setEquipmentPart(new EmptyEquipmentPart());

                            draggableItem.parentAfterDrag = transform;

                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(false);
                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(part);
                            break;
                        } else if (part is MeleeEquipmentPart)
                        {
                            MeleeEquipmentPart meleeEquipmentPart = new MeleeEquipmentPart();
                            meleeEquipmentPart.partLocation = PART_LOCATION.LEFT_ARM;
                            equipmentManager.equip(PART_LOCATION.LEFT_ARM, meleeEquipmentPart);

                            draggableItem.parentAfterDrag.GetComponent<InventorySlot>().SetEmpty(true);
                            draggableItem.parentAfterDrag.GetComponent<InventorySlot>().setEquipmentPart(new EmptyEquipmentPart());

                            draggableItem.parentAfterDrag = transform;

                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(false);
                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(part);
                            break;
                        }
                        else if (part is HoverBoots)
                        {
                            break;
                        }
                        else if (part is DoubleJumpEquipmentPart)
                        {
                            break;
                        }
                        break;
                    case BodyLocation.RightArm:
                        if (part is FlamethrowerEquipmentPart)
                        {
                            FlamethrowerEquipmentPart flamethrowerEquipmentPart = new FlamethrowerEquipmentPart();
                            flamethrowerEquipmentPart.partLocation = PART_LOCATION.RIGHT_ARM;
                            equipmentManager.equip(PART_LOCATION.RIGHT_ARM, flamethrowerEquipmentPart);

                            draggableItem.parentAfterDrag.GetComponent<InventorySlot>().SetEmpty(true);
                            draggableItem.parentAfterDrag.GetComponent<InventorySlot>().setEquipmentPart(new EmptyEquipmentPart());

                            draggableItem.parentAfterDrag = transform;

                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(false);
                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(part);
                            break;
                        } else if (part is MeleeEquipmentPart)
                        {
                            MeleeEquipmentPart meleeEquipmentPart = new MeleeEquipmentPart();
                            meleeEquipmentPart.partLocation = PART_LOCATION.RIGHT_ARM;                   
                            equipmentManager.equip(PART_LOCATION.RIGHT_ARM, meleeEquipmentPart);

                            draggableItem.parentAfterDrag.GetComponent<InventorySlot>().SetEmpty(true);
                            draggableItem.parentAfterDrag.GetComponent<InventorySlot>().setEquipmentPart(new EmptyEquipmentPart());

                            draggableItem.parentAfterDrag = transform;

                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(false);
                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(part);
                            break;
                        }
                        else if (part is HoverBoots)
                        {
                            break;
                        }
                        else if (part is DoubleJumpEquipmentPart)
                        {
                            break;
                        }
                        break;
                    case BodyLocation.Legs:
                        if (part is FlamethrowerEquipmentPart)
                        {
                            break;
                        }
                        else if (part is MeleeEquipmentPart)
                        {
                            break;
                        }
                        else if (part is HoverBoots)
                        {
                            HoverBoots hoverBoots = new HoverBoots();
                            hoverBoots.partLocation = PART_LOCATION.LEGS;
                            equipmentManager.equip(PART_LOCATION.LEGS, hoverBoots);

                            draggableItem.parentAfterDrag.GetComponent<InventorySlot>().SetEmpty(true);
                            draggableItem.parentAfterDrag.GetComponent<InventorySlot>().setEquipmentPart(new EmptyEquipmentPart());

                            draggableItem.parentAfterDrag = transform;

                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(false);
                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(part);
                            break;
                        }
                        else if (part is DoubleJumpEquipmentPart)
                        {
                            DoubleJumpEquipmentPart doubleJumpEquipmentPart = new DoubleJumpEquipmentPart();
                            doubleJumpEquipmentPart.partLocation = PART_LOCATION.LEGS;
                            equipmentManager.equip(PART_LOCATION.LEGS, doubleJumpEquipmentPart);

                            draggableItem.parentAfterDrag.GetComponent<InventorySlot>().SetEmpty(true);
                            draggableItem.parentAfterDrag.GetComponent<InventorySlot>().setEquipmentPart(new EmptyEquipmentPart());

                            draggableItem.parentAfterDrag = transform;

                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(false);
                            draggableItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(part);
                            break;
                        }
                        break;
                }
            }
        }
        else
        {
            GameObject droppedItem = eventData.pointerDrag;
            GameObject currentItem = transform.GetChild(0).gameObject;

            DraggableItem newItem = droppedItem.GetComponent<DraggableItem>();
            DraggableItem oldItem = currentItem.GetComponent<DraggableItem>();

            if (newItem.parentAfterDrag.TryGetComponent<InventorySlot>(out InventorySlot Is))
            {              
                PlayerEquipment equipmentManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEquipment>();
                EquipmentPart part = newItem.parentAfterDrag.GetComponent<InventorySlot>().GetEquipmentPart();
                EquipmentPart part2 = oldItem.parentAfterDrag.GetComponent<CharacterSlot>().GetEquipmentPart();

                switch (bodyLocation)
                {
                    case BodyLocation.Head:
                        if (part is FlamethrowerEquipmentPart)
                        {
                            break;
                        }
                        else if (part is MeleeEquipmentPart)
                        {
                            break;
                        }
                        else if (part is HoverBoots)
                        {
                            break;
                        }
                        else if (part is DoubleJumpEquipmentPart)
                        {
                            break;
                        }
                        break;
                    case BodyLocation.Body:
                        if (part is FlamethrowerEquipmentPart)
                        {
                            break;
                        }
                        else if (part is MeleeEquipmentPart)
                        {
                            break;
                        }
                        else if (part is HoverBoots)
                        {
                            break;
                        }
                        else if (part is DoubleJumpEquipmentPart)
                        {
                            break;
                        }
                        break;
                    case BodyLocation.LeftArm:
                        if (part is FlamethrowerEquipmentPart)
                        {
                            FlamethrowerEquipmentPart flamethrowerEquipmentPart = new FlamethrowerEquipmentPart();
                            flamethrowerEquipmentPart.partLocation = PART_LOCATION.LEFT_ARM;
                            equipmentManager.equip(PART_LOCATION.LEFT_ARM, flamethrowerEquipmentPart);

                            newItem.parentAfterDrag.GetComponent<InventorySlot>().SetEmpty(true);
                            newItem.parentAfterDrag.GetComponent<InventorySlot>().setEquipmentPart(new EmptyEquipmentPart());

                            oldItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(true);
                            oldItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(new EmptyEquipmentPart());

                            oldItem.transform.SetParent(newItem.parentAfterDrag);
                            oldItem.parentAfterDrag = newItem.parentAfterDrag;

                            newItem.parentAfterDrag = transform;

                            newItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(false);
                            newItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(part);

                            oldItem.parentAfterDrag.GetComponent<InventorySlot>().SetEmpty(false);
                            oldItem.parentAfterDrag.GetComponent<InventorySlot>().setEquipmentPart(part2);
                            break;
                        }
                        else if (part is MeleeEquipmentPart)
                        {
                            MeleeEquipmentPart meleeEquipmentPart = new MeleeEquipmentPart();
                            meleeEquipmentPart.partLocation = PART_LOCATION.LEFT_ARM;
                            equipmentManager.equip(PART_LOCATION.LEFT_ARM, meleeEquipmentPart);

                            newItem.parentAfterDrag.GetComponent<InventorySlot>().SetEmpty(true);
                            newItem.parentAfterDrag.GetComponent<InventorySlot>().setEquipmentPart(new EmptyEquipmentPart());

                            oldItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(true);
                            oldItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(new EmptyEquipmentPart());

                            oldItem.transform.SetParent(newItem.parentAfterDrag);
                            oldItem.parentAfterDrag = newItem.parentAfterDrag;

                            newItem.parentAfterDrag = transform;

                            newItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(false);
                            newItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(part);

                            oldItem.parentAfterDrag.GetComponent<InventorySlot>().SetEmpty(false);
                            oldItem.parentAfterDrag.GetComponent<InventorySlot>().setEquipmentPart(part2);
                            break;
                        }
                        else if (part is HoverBoots)
                        {
                            break;
                        }
                        else if (part is DoubleJumpEquipmentPart)
                        {
                            break;
                        }
                        break;
                    case BodyLocation.RightArm:
                        if (part is FlamethrowerEquipmentPart)
                        {
                            FlamethrowerEquipmentPart flamethrowerEquipmentPart = new FlamethrowerEquipmentPart();
                            flamethrowerEquipmentPart.partLocation = PART_LOCATION.RIGHT_ARM;
                            equipmentManager.equip(PART_LOCATION.RIGHT_ARM, flamethrowerEquipmentPart);

                            newItem.parentAfterDrag.GetComponent<InventorySlot>().SetEmpty(true);
                            newItem.parentAfterDrag.GetComponent<InventorySlot>().setEquipmentPart(new EmptyEquipmentPart());

                            oldItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(true);
                            oldItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(new EmptyEquipmentPart());

                            oldItem.transform.SetParent(newItem.parentAfterDrag);
                            oldItem.parentAfterDrag = newItem.parentAfterDrag;

                            newItem.parentAfterDrag = transform;

                            newItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(false);
                            newItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(part);

                            oldItem.parentAfterDrag.GetComponent<InventorySlot>().SetEmpty(false);
                            oldItem.parentAfterDrag.GetComponent<InventorySlot>().setEquipmentPart(part2);
                            break;
                        }
                        else if (part is MeleeEquipmentPart)
                        {
                            MeleeEquipmentPart meleeEquipmentPart = new MeleeEquipmentPart();
                            meleeEquipmentPart.partLocation = PART_LOCATION.RIGHT_ARM;
                            equipmentManager.equip(PART_LOCATION.RIGHT_ARM, meleeEquipmentPart);

                            newItem.parentAfterDrag.GetComponent<InventorySlot>().SetEmpty(true);
                            newItem.parentAfterDrag.GetComponent<InventorySlot>().setEquipmentPart(new EmptyEquipmentPart());

                            oldItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(true);
                            oldItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(new EmptyEquipmentPart());

                            oldItem.transform.SetParent(newItem.parentAfterDrag);
                            oldItem.parentAfterDrag = newItem.parentAfterDrag;

                            newItem.parentAfterDrag = transform;

                            newItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(false);
                            newItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(part);

                            oldItem.parentAfterDrag.GetComponent<InventorySlot>().SetEmpty(false);
                            oldItem.parentAfterDrag.GetComponent<InventorySlot>().setEquipmentPart(part2);
                            break;
                        }
                        else if (part is HoverBoots)
                        {
                            break;
                        }
                        else if (part is DoubleJumpEquipmentPart)
                        {
                            break;
                        }
                        break;
                    case BodyLocation.Legs:
                        if (part is FlamethrowerEquipmentPart)
                        {
                            break;
                        }
                        else if (part is MeleeEquipmentPart)
                        {
                            break;
                        }
                        else if (part is HoverBoots)
                        {
                            HoverBoots hoverBoots = new HoverBoots();
                            hoverBoots.partLocation = PART_LOCATION.LEGS;
                            equipmentManager.equip(PART_LOCATION.LEGS, hoverBoots);

                            newItem.parentAfterDrag.GetComponent<InventorySlot>().SetEmpty(true);
                            newItem.parentAfterDrag.GetComponent<InventorySlot>().setEquipmentPart(new EmptyEquipmentPart());

                            oldItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(true);
                            oldItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(new EmptyEquipmentPart());

                            oldItem.transform.SetParent(newItem.parentAfterDrag);
                            oldItem.parentAfterDrag = newItem.parentAfterDrag;

                            newItem.parentAfterDrag = transform;

                            newItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(false);
                            newItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(part);

                            oldItem.parentAfterDrag.GetComponent<InventorySlot>().SetEmpty(false);
                            oldItem.parentAfterDrag.GetComponent<InventorySlot>().setEquipmentPart(part2);
                            break;
                        }
                        else if (part is DoubleJumpEquipmentPart)
                        {
                            DoubleJumpEquipmentPart doubleJumpEquipmentPart = new DoubleJumpEquipmentPart();
                            doubleJumpEquipmentPart.partLocation = PART_LOCATION.LEGS;
                            equipmentManager.equip(PART_LOCATION.LEGS, doubleJumpEquipmentPart);

                            newItem.parentAfterDrag.GetComponent<InventorySlot>().SetEmpty(true);
                            newItem.parentAfterDrag.GetComponent<InventorySlot>().setEquipmentPart(new EmptyEquipmentPart());

                            oldItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(true);
                            oldItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(new EmptyEquipmentPart());

                            oldItem.transform.SetParent(newItem.parentAfterDrag);
                            oldItem.parentAfterDrag = newItem.parentAfterDrag;

                            newItem.parentAfterDrag = transform;

                            newItem.parentAfterDrag.GetComponent<CharacterSlot>().SetEmpty(false);
                            newItem.parentAfterDrag.GetComponent<CharacterSlot>().setEquipmentPart(part);

                            oldItem.parentAfterDrag.GetComponent<InventorySlot>().SetEmpty(false);
                            oldItem.parentAfterDrag.GetComponent<InventorySlot>().setEquipmentPart(part2);
                            break;
                        }
                        break;

                }
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
