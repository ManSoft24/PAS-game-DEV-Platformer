using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    int maxHealth = 100;
    int currentHealth;
    public Healthbar healthBar;

    Rigidbody2D rb;

    private Animator animator;
    [SerializeField] private GameObject deadScreen;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        StartGame();
    }

    void StartGame()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        transform.position = new Vector3(20, -2, 0);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }

        if (currentHealth <= 0)
        {
            die();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            restartGame();
        }
    }

    void restartGame()
    {
        Time.timeScale = 1f;
        StartGame();
        deadScreen.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void die()
    {
        Time.timeScale = 0f;
        deadScreen.SetActive(true);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Void"))
        {
            TakeDamage(30);
            if (currentHealth > 0)
            {
                transform.position = new Vector3(20, -2, 0);
            }
        }
    }
}