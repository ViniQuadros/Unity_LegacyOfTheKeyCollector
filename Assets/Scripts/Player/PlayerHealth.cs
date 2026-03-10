using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int currentHealth = 100;
    private int maxHealth = 100;

    [Header("UI")]
    public TextMeshProUGUI healthTxt;
    public Image statusIcon;

    [Header("Icons")]
    public Sprite good;
    public Sprite littleGood;
    public Sprite neutral;
    public Sprite littleBad;
    public Sprite bad;

    void Start()
    {
        currentHealth = maxHealth;
        CheckStatus();
    }

    public void Heal(int heal)
    {
        currentHealth += heal;
        if (currentHealth >= maxHealth)
            currentHealth = maxHealth;

        CheckStatus();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Die");
        }
        CheckStatus();
    }

    private void CheckStatus()
    {
        healthTxt.text = currentHealth.ToString();

        if (currentHealth == maxHealth)
            statusIcon.sprite = good;
        else if (currentHealth < maxHealth && currentHealth > maxHealth / 2)
            statusIcon.sprite = good;
        else if (currentHealth < maxHealth / 2 && currentHealth >= maxHealth * 0.25f)
            statusIcon.sprite = neutral;
        else if (currentHealth < maxHealth * 0.25f && currentHealth >= maxHealth * 0.1f)
            statusIcon.sprite = littleBad;
        else if (currentHealth < maxHealth * 0.1f)
            statusIcon.sprite = bad;
    }
}
