using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    void Start()
    {
        SpawnPoint[] points = FindObjectsByType<SpawnPoint>(FindObjectsSortMode.None);

        foreach (var point in points)
        {
            if (point.spawnID == SceneTransition.spawnID)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.transform.position = point.transform.position;
                Debug.Log(SceneTransition.spawnID);
                break;
            }
        }
    }
}
