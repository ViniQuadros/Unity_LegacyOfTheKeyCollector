using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowText : MonoBehaviour
{
    public TextMeshProUGUI pressText;
    private bool canPassScene = false;

    public IEnumerator FadeText(float duration)
    {
        float elapsed = 0f;

        while (elapsed <= duration)
        {
            pressText.color = new Color(255, 255, 255, elapsed);
            elapsed += Time.deltaTime;
            yield return null;
        }

        pressText.color = new Color(255, 255, 255, 1);
        canPassScene = true;
    }

    public void PassScene()
    {
        if (canPassScene)
        {
            SceneManager.LoadScene("World");
        }
    }
}
