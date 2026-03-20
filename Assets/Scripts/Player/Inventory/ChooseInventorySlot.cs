using UnityEngine;
using UnityEngine.InputSystem;

public class ChooseInventorySlot : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction selectAction;
    private Inventory playerInventory;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        selectAction = playerInput.actions["SelectInventorySlot"];
    }

    void Update()
    {
        if (selectAction.WasPressedThisFrame())
        {
            
        }
    }
}
