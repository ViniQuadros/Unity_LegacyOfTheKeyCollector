using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GridLayoutGroup inventorySlots;
    public GameObject slot;

    private int currentInventorySlot = 0;
    private int maxGridSize = 10;
    private bool isFull = false;

    private int currentInventoryIndex = 0;

    private PlayerInput playerInput;
    private InputAction useItem;

    private void Start()
    {
        for (int i = 0; i < maxGridSize; i++)
        {
            Instantiate(slot, inventorySlots.transform);
        }

        playerInput = GetComponent<PlayerInput>();
        useItem = playerInput.actions["UseItem"];

        Image selectedSlot = inventorySlots.transform.GetChild(currentInventoryIndex).gameObject.GetComponent<Image>();
        if (selectedSlot != null)
            selectedSlot.color = Color.green;
    }

    private void Update()
    {
        SelectInventoryItem();
        UseItem();
    }

    public void AddToInventory(InventoryItems item)
    {
        if (isFull)
            return;

        foreach (Transform i in inventorySlots.transform)
        {
            Slot newItem = i.GetComponent<Slot>();

            if (newItem.GetItem() != null)
            {
                if (newItem.GetItemName() == item.itemName)
                {
                    newItem.AddAmount();
                    break;
                }
            }
            else if (newItem.GetItem() == null)
            {
                newItem.SetItemToSlot(item);
                currentInventorySlot++;
                if (currentInventorySlot == maxGridSize)
                    isFull = true;
                break;
            }
        }
    }

    public bool GetIsFull() 
    { 
        return isFull;
    }

    private void SelectInventoryItem()
    {
        float scrollY = Mouse.current.scroll.ReadValue().y;

        if (scrollY > 0)
            currentInventoryIndex++;
        else if (scrollY < 0)
            currentInventoryIndex--;
        else
            return;

        if (currentInventoryIndex >= maxGridSize)
            currentInventoryIndex = 0;
        if (currentInventoryIndex < 0)
            currentInventoryIndex = maxGridSize - 1;

        for (int i = 0; i < inventorySlots.transform.childCount; i++)
        {
            Image slotImage = inventorySlots.transform.GetChild(i).GetComponent<Image>();
            if (slotImage != null)
                slotImage.color = Color.white;
        }

        Image selectedSlot = inventorySlots.transform.GetChild(currentInventoryIndex).gameObject.GetComponent<Image>();
        if (selectedSlot != null)
            selectedSlot.color = Color.green;
    }

    private void UseItem()
    {
        if (useItem.WasPressedThisFrame())
        {
            Slot slot = inventorySlots.transform.GetChild(currentInventoryIndex).gameObject.GetComponent<Slot>();
            if (slot.GetItem() != null)
            {
                slot.GetItem().collectableEffect.ApplyEffect(gameObject, slot);
            }
        }
    }
}
