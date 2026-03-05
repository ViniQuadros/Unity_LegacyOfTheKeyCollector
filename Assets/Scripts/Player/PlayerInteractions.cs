using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractions : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction interact;

    float radius = 0.5f;
    float distance = 1f;

    public LayerMask interactableLayer;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        interact = playerInput.actions["Interact"];
    }

    void Update()
    {
        if (interact.WasPressedThisFrame())
        {
            Vector2 origin = transform.position;
            Vector2 direction = transform.up;
            RaycastHit2D hit2D = Physics2D.CircleCast(origin, radius, direction, distance, interactableLayer);
            if (hit2D.collider != null && hit2D.collider.TryGetComponent(out I_Interactable interactable))
            {
                interactable.Interact();
                Debug.Log(hit2D.collider);
            }
        }
    }
}
