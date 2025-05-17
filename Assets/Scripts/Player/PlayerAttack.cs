using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(PlayerEquipment))]
public class PlayerAttack : MonoBehaviour
{
    PlayerEquipment equip;
    public PART_LOCATION activeAttackingEquip = PART_LOCATION.LEFT_ARM;

    private void Start()
    {
        equip = GetComponent<PlayerEquipment>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        EquipmentPart part;
        equip.equipment.TryGetValue(activeAttackingEquip, out part);

        Debug.Log(context.performed);
        if (context.performed)
        {
           
            if (part is SustainedEquipment)
            {
                var sus = part as SustainedEquipment;
                sus.ActionStart();
            } else
            {
                part.Action();
            }
        } else if (context.canceled)
        {
            if (part is SustainedEquipment && part.GetType() != typeof(MeleeEquipmentPart))
            {
                var sus = part as SustainedEquipment;
                sus.ActionEnd();
            }
        }
    }
}
