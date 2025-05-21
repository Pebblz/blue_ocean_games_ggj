using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterSlot : Slot, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;

            //add code for equiping the part to the character in game
        } else
        {
            GameObject droppedItem = eventData.pointerDrag;
            GameObject currentItem = transform.GetChild(0).gameObject;

            DraggableItem newItem = droppedItem.GetComponent<DraggableItem>();
            DraggableItem oldItem = currentItem.GetComponent<DraggableItem>();

            oldItem.transform.SetParent(newItem.parentAfterDrag);

            newItem.parentAfterDrag = transform;

            //add code for equiping the part to the character in game
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
