using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    int maxHealth = 100;
    int currentHealth;
    public Healthbar healthBar;
    [SerializeField] private GameObject deadScreen;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        transform.position = new Vector3(20, -2, 0);
    }


    void Update()
    {
        if (currentHealth <= 0)
        {
            die();
            deadScreen.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                deadScreen.SetActive(false);
                Time.timeScale = 1f;
                Start();
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void die()
    {

        Time.timeScale = 0f;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Void"))
        {
            TakeDamage(50);
            transform.position = new Vector3(20, -2, 0);
        }
    }
}