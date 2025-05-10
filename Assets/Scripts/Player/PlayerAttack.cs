using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(PlayerEquipment))]
public class PlayerAttack : MonoBehaviour
{
    PlayerEquipment equip;

    private void Start()
    {
        equip = GetComponent<PlayerEquipment>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Attack!");
        }
    }
}
