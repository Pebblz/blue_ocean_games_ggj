using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private bool isInteractable;
    [SerializeField] private bool isEmpty;
    [SerializeField] private Image slotImage;
    public Sprite image;
    [SerializeField] private int slotIndex;
    [SerializeField] private EquipmentPart part;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        slotImage = GetComponent<Image>();
        slotImage.sprite = image;
        isEmpty = false;
        isInteractable = false;
        part = null;
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void SetImage(Image slotImage)
    {
        this.slotImage = slotImage;
    }

    public Image GetImage()
    {
        return slotImage;
    }

    public void SetSlotIndex(int slotIndex)
    {
        this.slotIndex = slotIndex;
    }

    public int GetSlotIndex() 
    { 
        return slotIndex;
    }

    public void SetInteractable(bool isInteractable)
    {
        this.isInteractable = isInteractable;
    }
    public bool IsInteractable()
    {
        return isInteractable;
    }

    public void SetEmpty(bool isEmpty)
    {
        this.isEmpty = isEmpty;
    }

    public bool IsEmpty()
    {
        return this.isEmpty;
    }

    public void setEquipmentPart(EquipmentPart part)
    {
        this.part = part;
    }

    public EquipmentPart GetEqipmentPart()
    {
        return part;
    }
}
