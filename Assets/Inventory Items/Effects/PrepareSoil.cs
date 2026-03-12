using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Item Effects/PrepareSoil")]
public class PrepareSoil : CollectableEffects
{
    private Tilemap plantingTiles;
    public TileBase soil;

    public override void ApplyEffect(GameObject target, Slot slot)
    {
        plantingTiles = GameObject.FindGameObjectWithTag("TerrainTiles").GetComponent<Tilemap>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (plantingTiles.GetTile(Vector3Int.RoundToInt(player.transform.position)) == null)
        {
            plantingTiles.SetTile(Vector3Int.RoundToInt(player.transform.position), soil);
        }
    }
}