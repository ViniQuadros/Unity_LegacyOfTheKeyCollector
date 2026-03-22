using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Item Effects/PrepareSoil")]
public class PrepareSoil : CollectableEffects
{
    private Tilemap terrainTiles;
    private Tilemap plantingTiles;

    public TileBase soil;

    public override void ApplyEffect(GameObject target, Slot slot)
    {
        terrainTiles = GameObject.FindGameObjectWithTag("TerrainTiles").GetComponent<Tilemap>();
        plantingTiles = GameObject.FindGameObjectWithTag("PreviewTiles").GetComponent<Tilemap>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerInteractions playerInteractions = player.GetComponent<PlayerInteractions>();

        if (!playerInteractions.GetCanPlant()) return;
        if (!playerInteractions.GetHasPreview()) return;

        Vector3Int tilePos = playerInteractions.GetLastPreview();

        playerInteractions.GetTilemap().SetTile(tilePos, null);
        playerInteractions.SetHasPreview(false);

        if (terrainTiles.GetTile(tilePos) == null && plantingTiles != null)
        {
            plantingTiles.SetTile(tilePos, soil);
        }
    }
}