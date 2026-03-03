using UnityEngine;

public class CollectItems : MonoBehaviour
{
    [SerializeField] private InventoryItems item;
    private Inventory inventory;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inventory.AddToInventory(item);
        }

        Destroy(gameObject);
    }
}
