using UnityEngine;

public class UseAttachedCamera : MonoBehaviour
{
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject camera = player.transform.Find("Main Camera").gameObject;
        camera.SetActive(true);
    }
}
