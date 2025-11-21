using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public Image healthBar;
    public GameObject player;

    private bool isDead;

    public GameManagerScript gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHealth = health;
        // Ensure maxHealth is valid to avoid division by zero later
        // If inspector values are very small (1 or less), assume the user expects a 100-based health scale
        if (maxHealth <= 1f)
        {
            maxHealth = 100f;
            if (health <= 1f) health = maxHealth;
        }
        else if (maxHealth <= 0f)
        {
            maxHealth = 1f;
            if (health <= 0f) health = maxHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar != null  && !isDead)
        {
            isDead = true;
            //gameManager.gameOver();
            float fill = (maxHealth > 0f) ? (health / maxHealth) : 0f;
            healthBar.fillAmount = Mathf.Clamp(fill, 0f, 1f);
        }
        if (health <= 0f)
        {
            Debug.Log("playerHealth: player died (health reached 0).");

                gameManager.gameOver();
        
        }
    }

    // Apply damage to the player, clamped to 0
    public void TakeDamage(float amount)
    {
        health = Mathf.Max(health - amount, 0f);
        // Update the health bar immediately so UI reflects damage in the same frame
        UpdateHealthBar();

        if (health <= 0f)
        {
            gameManager.gameOver();
            Time.timeScale = 0f; // Pause the game
            Debug.Log("playerHealth: player died (health reached 0).");
            player.SetActive(false);
        }
    }
    
    // Heal the player by an amount (clamped to max)
    public void Heal(float amount)
    {
        health = Mathf.Min(health + amount, maxHealth);
        UpdateHealthBar();
    }
    
    // Restore the player's health to full
    public void RestoreFullHealth()
    {
        health = maxHealth;
        UpdateHealthBar();
    }

    // Update the UI health bar safely
    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            float fill = (maxHealth > 0f) ? (health / maxHealth) : 0f;
            healthBar.fillAmount = Mathf.Clamp(fill, 0f, 1f);
        }
    }
}
