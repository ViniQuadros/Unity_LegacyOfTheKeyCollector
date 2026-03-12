using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/Heal")]
public class HealEffect : CollectableEffects
{
    public int amount;

    public override void ApplyEffect(GameObject target, Slot slot)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth.isFullHealth())
        {
           playerHealth.Heal(amount);
           slot.RemoveAmount();
        }
    }
}
