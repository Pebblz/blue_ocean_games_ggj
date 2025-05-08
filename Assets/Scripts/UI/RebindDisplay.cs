using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class RebindDisplay : MonoBehaviour
{
    [SerializeField] private InputActionReference actionRefrence;
    //[SerializeField] private int controlSceame = 0;
    [SerializeField] private TMP_Text bindDisplayNameText;
    [SerializeField] private GameObject startRebindObject;
    [SerializeField] private GameObject waitingForInputObject;

    
    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;
    public void StartRebinding()
    {
        startRebindObject.SetActive(false);
        waitingForInputObject.SetActive(true);
        actionRefrence.action.Disable();
        actionRefrence.action.PerformInteractiveRebinding().
            WithControlsExcluding("Mouse").
            OnMatchWaitForAnother(.1f).
            OnComplete(operation => RebindComplate());
    }
    private void RebindComplate()
    {
        print(true);
        int bindingIndex = actionRefrence.action.GetBindingIndexForControl(actionRefrence.action.controls[0]);
        actionRefrence.action.Enable();
        bindDisplayNameText.text = InputControlPath.ToHumanReadableString(
            actionRefrence.action.bindings[bindingIndex].effectivePath, 
            InputControlPath.HumanReadableStringOptions.OmitDevice);
        rebindingOperation.Dispose();
        startRebindObject.SetActive(true);
        waitingForInputObject.SetActive(false);
    }
    public void ResetBinding()
    {
        int bindingIndex = actionRefrence.action.GetBindingIndexForControl(actionRefrence.action.controls[0]);
        actionRefrence.action.RemoveBindingOverride(bindingIndex);
        bindDisplayNameText.text = InputControlPath.ToHumanReadableString(
    actionRefrence.action.bindings[bindingIndex].effectivePath,
    InputControlPath.HumanReadableStringOptions.OmitDevice);
    }
}
