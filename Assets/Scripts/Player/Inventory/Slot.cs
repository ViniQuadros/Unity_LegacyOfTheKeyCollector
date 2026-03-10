using System.Collections;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private InventoryItems item;

    public Image icon;
    public TextMeshProUGUI amount;

    public Image descriptionPanel;
    public TextMeshProUGUI i_name;
    public TextMeshProUGUI description;

    private int currentAmount = 0;

    private GameObject dragIcon;
    private RectTransform dragPlane;
    private static Slot dragSlot;

    private void Start()
    {
        descriptionPanel.color = new Color(descriptionPanel.color.r, descriptionPanel.color.g, descriptionPanel.color.b, 0);
        i_name.color = new Color(i_name.color.r, i_name.color.g, i_name.color.b, 0);
        description.color = new Color(description.color.r, description.color.g, description.color.b, 0);
        descriptionPanel.gameObject.SetActive(false);

        if (item != null)
        {
            SetItemToSlot(item);
        }
    }

    public void SetItemToSlot(InventoryItems newItem)
    {
        item = newItem;
        icon.sprite = newItem.itemIcon;
        AddAmount();
        i_name.text = newItem.itemName;
        description.text = newItem.itemDescription;
    }

    public static void RemoveItemFromSlot()
    {
        if (dragSlot == null)
            return;

        dragSlot.icon.sprite = null;
        dragSlot.amount.text = "";
        dragSlot.i_name.text = "";
        dragSlot.description.text = "";
        dragSlot.item = null;
        dragSlot.currentAmount = 0;

        dragSlot = null;
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

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item == null)
            return;
        if (dragSlot != null)
            return;

        dragSlot = this;

        var canvas = GetComponentInParent<Canvas>();
        if (canvas == null)
            return;

        dragPlane = canvas.transform as RectTransform;

        dragIcon = new GameObject("DragIcon");
        dragIcon.transform.SetParent(canvas.transform, false);
        dragIcon.transform.SetAsLastSibling();

        Image img = dragIcon.AddComponent<Image>();
        img.sprite = icon.sprite;
        img.raycastTarget = false;

        RectTransform rt = dragIcon.GetComponent<RectTransform>();
        rt.sizeDelta = icon.rectTransform.sizeDelta;

        SetDragIconPosition(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        SetDragIconPosition(eventData);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (Slot.dragSlot == null)
            return;

        GameObject target = eventData.pointerCurrentRaycast.gameObject;

        if (target == null)
            return;

        Slot newSlotForItem = target.GetComponentInParent<Slot>();

        if (newSlotForItem == null)
            return;
        if (newSlotForItem == Slot.dragSlot)
            return;

        InventoryItems draggedItem = Slot.dragSlot.GetItem();
        if (draggedItem == null)
            return;

        if (newSlotForItem.GetItem() == null)
        {
            newSlotForItem.SetItemToSlot(draggedItem);
            Slot.RemoveItemFromSlot();
        }
        else if (newSlotForItem.GetItem() == draggedItem)
        {
            newSlotForItem.AddAmount();
            Slot.RemoveItemFromSlot();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragIcon != null)
            Destroy(dragIcon);

        dragSlot = null;
    }

    private void SetDragIconPosition(PointerEventData data)
    {
        if (item == null)
            return;

        var obj = dragIcon.transform;

        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(
            dragPlane,
            data.position,
            data.pressEventCamera,
            out globalMousePos))
        {
            obj.position = globalMousePos;
            obj.rotation = dragPlane.rotation;
        }
    }
}
