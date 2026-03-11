using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/Plant Seed")]
public class PlantSeed : CollectableEffects
{
    public override void ApplyEffect(GameObject target)
    {
        Debug.Log("Planted");
    }
}

