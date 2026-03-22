using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerInteractions : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction interact;
    private InputAction checkTilesPlacement;

    float radius = 0.5f;
    float distance = 1f;

    public LayerMask interactableLayer;

    private bool canPlant = true;

    public Tile tilePreview;
    private Tilemap tilemap;
    private Vector3Int lastPreviewPos;
    private bool hasPreview = false;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        interact = playerInput.actions["Interact"];
        checkTilesPlacement = playerInput.actions["PlaceTiles"];
        tilemap = GameObject.FindGameObjectWithTag("TerrainTiles").GetComponent<Tilemap>();
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

        if (checkTilesPlacement.IsPressed())
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePos.z = 0;

            float maxDistance = 1f;

            Vector3 dir = mousePos - transform.position;
            if (dir.magnitude > maxDistance)
                dir = dir.normalized * maxDistance;

            Vector3 targetPos = transform.position + dir;

            targetPos.x = Mathf.Round(targetPos.x);
            targetPos.y = Mathf.Round(targetPos.y);

            Vector3Int tilePos = Vector3Int.RoundToInt(targetPos);

            if (tilemap != null)
            {
                if (hasPreview && tilePos != lastPreviewPos)
                    tilemap.SetTile(lastPreviewPos, null);

                tilemap.SetTile(tilePos, tilePreview);

                lastPreviewPos = tilePos;
                hasPreview = true;
            }
        }

        if (checkTilesPlacement.WasReleasedThisFrame())
        {
            if (hasPreview)
            {
                tilemap.SetTile(lastPreviewPos, null);
                hasPreview = false;
            }
        }
    }

    //Getters and setters for the hoe code to place the terrain at the right place
    public Vector3Int GetLastPreview() { return lastPreviewPos; }
    public void SetCanPlant(bool newCanPlant) { canPlant = newCanPlant; }
    public bool GetCanPlant() { return canPlant; }
    public bool GetHasPreview() { return hasPreview; }
    public void SetHasPreview(bool newHasPreview) { hasPreview = newHasPreview; }
    public Tilemap GetTilemap() { return tilemap; }
}
