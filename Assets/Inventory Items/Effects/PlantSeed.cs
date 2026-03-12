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
        tilemap = GameObject.FindGameObjectWithTag("TerrainTiles").GetComponent<Tilemap>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3Int tilePos = tilemap.WorldToCell(player.transform.position);

        if (tilemap.GetTile(tilePos) == tilePlants)
        {
            Vector3 worldPos = tilemap.GetCellCenterWorld(tilePos);
            Instantiate(seed, worldPos, Quaternion.identity);
            slot.RemoveAmount();
        }
    }
}

