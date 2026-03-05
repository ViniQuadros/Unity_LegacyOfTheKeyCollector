using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/Heal")]
public class HealEffect : CollectableEffects
{
    public float amount;

    public override void ApplyEffect(GameObject target)
    {
        Debug.Log("Healed for " + amount);
    }
}
