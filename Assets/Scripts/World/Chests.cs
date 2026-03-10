using UnityEngine;

public class Chests : MonoBehaviour, I_Interactable
{
    public GameObject chestCanvas;

    private bool isActive = false;

    void Start()
    {
        chestCanvas.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    public void Interact()
    {
        isActive = true;
        chestCanvas.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isActive == true)
        {
            CloseChestUI();
        }
    }

    public void CloseChestUI()
    {
        chestCanvas.SetActive(false);
        isActive = false;
    }
}
