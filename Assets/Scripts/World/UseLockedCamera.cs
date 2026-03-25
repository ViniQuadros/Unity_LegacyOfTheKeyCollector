using UnityEngine;

public class UseLockedCamera : MonoBehaviour
{
    public bool activateMainCamera = true;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject camera = player.transform.Find("Main Camera").gameObject;
        camera.SetActive(activateMainCamera);
        Debug.Log(activateMainCamera);
    }
}
