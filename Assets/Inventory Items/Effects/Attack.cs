using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/Attack")]
public class Attack : CollectableEffects
{
    public float damage;

    public override void ApplyEffect(GameObject target)
    {
        Debug.Log("Damage: " + damage);
    }
}
