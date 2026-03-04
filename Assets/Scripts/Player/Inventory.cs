using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GridLayoutGroup inventorySlots;
    public GameObject slot;

    private int currentInventorySlot = 0;
    private int maxGridSize = 10;
    private bool isFull = false;

    private void Start()
    {
        for (int i = 0; i < maxGridSize; i++)
        {
            Instantiate(slot, inventorySlots.transform);
        }
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
                newItem.SetItem(item);
                newItem.SetIcon(item.itemIcon);
                newItem.AddAmount();
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
}
