using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/Heal")]
public class HealEffect : CollectableEffects
{
    public int amount;

    public override void ApplyEffect(GameObject target)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth.isFullHealth())
        {
           playerHealth.Heal(amount);
        }
    }
}
