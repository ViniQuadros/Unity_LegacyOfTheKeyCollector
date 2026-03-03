using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<InventoryItems> playerInventory = new List<InventoryItems>();

    public void AddToInventory(InventoryItems item)
    {
        if (playerInventory.Contains(item) && item.maxAmount <= 1)
            return;

        playerInventory.Add(item);

        foreach (var c in playerInventory)
        {
            Debug.Log(c.itemName + "\n");
        }
    }
}
