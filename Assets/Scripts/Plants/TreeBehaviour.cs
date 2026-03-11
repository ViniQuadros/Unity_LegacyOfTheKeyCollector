using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TreeBehaviour : MonoBehaviour, I_Interactable
{
    public Sprite emptyTree;
    public Sprite fullTree;
    public GameObject fruit;
    public float force;

    private float cooldown = 180f;
    private bool hasFruit = true;
    private SpriteRenderer currentSprite;
    [SerializeField] private GameObject player;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        currentSprite = GetComponent<SpriteRenderer>();
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
        StartCoroutine(RefillTree());
    }

    private IEnumerator RefillTree()
    {
        yield return new WaitForSeconds(cooldown);
        currentSprite.sprite = fullTree;
        hasFruit = true;
    }
}