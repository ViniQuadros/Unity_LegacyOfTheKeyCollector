using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;

    private Camera mainCamera;
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private InputAction moveAction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];

        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.z = -10;

        mainCamera.transform.position = cameraPosition;
    }

    private void FixedUpdate()
    {
        if (moveAction != null) {
            Move();
        }
    }

    void Move()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector2 movementDirection = transform.up * input.y + transform.right * input.x;
        movementDirection.Normalize();
        rb.linearVelocity = movementDirection;
    }
}
