using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayerToPlace : MonoBehaviour, I_Interactable
{
    public string spawnID;
    public string sceneName;

    public void Interact()
    {
        SceneTransition.spawnID = spawnID;
        SceneManager.LoadScene(sceneName);
    }
}
