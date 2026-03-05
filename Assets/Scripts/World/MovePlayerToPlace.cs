using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayerToPlace : MonoBehaviour, I_Interactable
{
    public string sceneName;

    public void Interact()
    {
        SceneManager.LoadScene(sceneName);
    }
}
