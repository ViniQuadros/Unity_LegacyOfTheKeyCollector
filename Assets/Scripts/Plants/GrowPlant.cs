using System.Collections;
using UnityEngine;

public class GrowPlant : MonoBehaviour, I_Interactable
{
    private int phases = 0;
    public Sprite[] growStages;
    public GameObject plant;
    private SpriteRenderer spriteRenderer;

    private bool isGrown = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = growStages[phases];
        StartCoroutine(StartGrowing());
    }

    private IEnumerator StartGrowing()
    {
        for (int i = 0; i < growStages.Length - 1; i++)
        {
            yield return new WaitForSeconds(1);
            phases++;
            spriteRenderer.sprite = growStages[phases];
        }
        isGrown = true;
    }

    public void Interact()
    {
        Debug.Log("Interacted");
        if (isGrown && plant != null)
        {
            Instantiate(plant, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
