using UnityEngine;

public enum ItemType
{
    Collectible,
    Weapon
}

[CreateAssetMenu(fileName = "InventoryItems", menuName = "Scriptable Objects/InventoryItems")]
public class InventoryItems : ScriptableObject
{
    public Sprite itemIcon;
    public string itemName;
    public string itemDescription;
    public ItemType itemType;
    public bool stackable;
    public int maxAmount;
    public CollectableEffects collectableEffect;
}
