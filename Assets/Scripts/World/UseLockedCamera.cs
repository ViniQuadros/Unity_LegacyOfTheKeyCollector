using UnityEngine;

public class UseLockedCamera : MonoBehaviour
{
    void Start()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        camera.SetActive(false);
    }
}
