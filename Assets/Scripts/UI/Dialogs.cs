using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dialogs : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    private InputAction inputAction;

    public string text;
    public TextMeshProUGUI dialogText;
    public float textSpeed = 0.1f;
    public ShowText showText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        inputAction = playerInput.actions["SkipDialog"];

        StartCoroutine(ReadText());
    }

    private void Update()
    {
        if (inputAction.WasPressedThisFrame())
        {
            textSpeed = 0.01f;
            showText.PassScene();
        }
    }

    private IEnumerator ReadText()
    {
        StringBuilder writtenText = new StringBuilder();
        foreach (char c in text) {
            dialogText.text = writtenText.Append(c).ToString();
            yield return new WaitForSeconds(textSpeed);
        }
        
        StartCoroutine(showText.FadeText(1f));
    }
}
