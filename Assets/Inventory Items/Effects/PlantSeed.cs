using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Item Effects/Plant Seed")]
public class PlantSeed : CollectableEffects
{
    private Tilemap tilemap;
    public Tile tilePlants;
    public GameObject seed;

    public override void ApplyEffect(GameObject target, Slot slot)
    {
        tilemap = GameObject.FindGameObjectWithTag("PreviewTiles").GetComponent<Tilemap>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        TileBase tileB = tilemap.GetTile(Vector3Int.RoundToInt(player.transform.position));

        if (tileB == tilePlants)
        {
            Vector3 worldPos = tilemap.GetCellCenterWorld(Vector3Int.RoundToInt(player.transform.position));

            int seedLayer = LayerMask.GetMask("Interactable");
            Collider2D existing = Physics2D.OverlapPoint(worldPos, seedLayer);
            if (existing != null) return;

            Instantiate(seed, worldPos, Quaternion.identity);
            slot.RemoveAmount();
        }
    }
}

