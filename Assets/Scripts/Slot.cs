using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private InventoryItems item;
    public Image icon;
    public TextMeshProUGUI amount;

    private int currentAmount = 0;

    public void SetIcon(Sprite newIcon)
    {
        icon.sprite = newIcon;
    }

    public void AddAmount()
    {
        if (item.itemType == ItemType.Weapon)
        {
            amount.text = "";
        }
        else
        {
            currentAmount++;
            amount.text = currentAmount.ToString();
        }
    }

    public void SetItem(InventoryItems newItem)
    {
        item = newItem;
    }

    public string GetItemName()
    {
        return item.itemName;
    }

    public InventoryItems GetItem()
    {
        return item;
    }

    public int GetAmount()
    {
        return currentAmount;
    }
}
