using System;
using System.Collections;
using UnityEngine;

public class TreeBehaviour : MonoBehaviour, I_Interactable
{
    public Sprite emptyTree;
    public Sprite fullTree;
    public GameObject fruit;
    public float force;

    private float refillTime;
    private float cooldown = 180f;
    private bool hasFruit = true;
    private SpriteRenderer currentSprite;
    [SerializeField] private GameObject player;


    void Start()
    {
        currentSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!hasFruit && Time.time >= refillTime)
        {
            currentSprite.sprite = fullTree;
            hasFruit = true;
        }
    }

    public void Interact()
    {
        if (!hasFruit) return;

        GameObject treeFruit = Instantiate(fruit, transform.position, Quaternion.identity);
        Rigidbody2D rb = treeFruit.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(Vector2.down * force, ForceMode2D.Impulse);
        }

        currentSprite.sprite = emptyTree;
        hasFruit = false;
        refillTime = Time.time + cooldown;
    }
}