using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Item Effects/UseHomeKey")]
public class UseHomeKey : CollectableEffects
{
    public override void ApplyEffect(GameObject target, Slot slot)
    {
        Debug.Log("Going Home");
    }
}