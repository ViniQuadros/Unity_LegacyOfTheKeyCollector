using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/Attack")]
public class Attack : CollectableEffects
{
    public float damage;

    public override void ApplyEffect(GameObject target, Slot slot)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerAnimation animator = player.GetComponent<PlayerAnimation>();
        animator.SetIsAttacking();
    }
}
