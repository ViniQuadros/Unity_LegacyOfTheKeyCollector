using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private InventoryItems item;

    public Image icon;
    public TextMeshProUGUI amount;

    public Image descriptionPanel;
    public TextMeshProUGUI i_name;
    public TextMeshProUGUI description;

    private int currentAmount = 0;

    private void Start()
    {
        descriptionPanel.color = new Color(descriptionPanel.color.r, descriptionPanel.color.g, descriptionPanel.color.b, 0);
        i_name.color = new Color(i_name.color.r, i_name.color.g, i_name.color.b, 0);
        description.color = new Color(description.color.r, description.color.g, description.color.b, 0);
        descriptionPanel.gameObject.SetActive(false);
    }

    public void SetItemToSlot(InventoryItems newItem)
    {
        item = newItem;
        icon.sprite = newItem.itemIcon;
        AddAmount();
        i_name.text = newItem.itemName;
        description.text = newItem.itemDescription;
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

    public void RemoveAmount()
    {
        if(item.stackable == true)
        {
            currentAmount--;
            amount.text = currentAmount.ToString();
            if (currentAmount == 0)
            {
                amount.text = "";
                icon.sprite = null;
                item = null;
            }
        }
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

    private IEnumerator ShowDescription()
    {
        float elapsed = 0f;
        float duration = .4f;

        descriptionPanel.gameObject.SetActive(true);

        while (elapsed < duration)
        {
            descriptionPanel.color = new Color(descriptionPanel.color.r, descriptionPanel.color.g, descriptionPanel.color.b, Mathf.Lerp(0, 1, elapsed / duration));
            i_name.color = new Color(i_name.color.r, i_name.color.g, i_name.color.b, Mathf.Lerp(0, 1, elapsed / duration));
            description.color = new Color(description.color.r, description.color.g, description.color.b, Mathf.Lerp(0, 1, elapsed / duration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        descriptionPanel.color = new Color(descriptionPanel.color.r, descriptionPanel.color.g, descriptionPanel.color.b, 1);
        i_name.color = new Color(i_name.color.r, i_name.color.g, i_name.color.b, 1);
        description.color = new Color(description.color.r, description.color.g, description.color.b, 1);
    }

    private IEnumerator HideDescription()
    {
        float elapsed = 0f;
        float duration = .4f;

        while (elapsed >= duration)
        {
            descriptionPanel.color = new Color(descriptionPanel.color.r, descriptionPanel.color.g, descriptionPanel.color.b, Mathf.Lerp(1, 0, elapsed / duration));
            i_name.color = new Color(i_name.color.r, i_name.color.g, i_name.color.b, Mathf.Lerp(1, 0, elapsed / duration));
            description.color = new Color(description.color.r, description.color.g, description.color.b, Mathf.Lerp(1, 0, elapsed / duration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        descriptionPanel.color = new Color(descriptionPanel.color.r, descriptionPanel.color.g, descriptionPanel.color.b, 0);
        i_name.color = new Color(i_name.color.r, i_name.color.g, i_name.color.b, 0);
        description.color = new Color(description.color.r, description.color.g, description.color.b, 0);

        descriptionPanel.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            StartCoroutine(ShowDescription());
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (item != null)
        {
            StartCoroutine(HideDescription());
        }
    }
}
