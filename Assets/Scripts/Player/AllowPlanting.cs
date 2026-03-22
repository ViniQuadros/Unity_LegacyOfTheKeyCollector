using UnityEngine;

public class AllowPlanting : MonoBehaviour
{
    [SerializeField] private PlayerInteractions playerInteractions;
    private bool canPlayerPlant = true;

    private void Start()
    {
        if (playerInteractions == null)
            playerInteractions = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteractions>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canPlayerPlant = !canPlayerPlant;
        playerInteractions.SetCanPlant(canPlayerPlant);
        Debug.Log(canPlayerPlant);
    }
}
