using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    int maxHealth = 100;
    int currentHealth;
    public Healthbar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
    {
        TakeDamage(20);
    }
      
    }

    public void TakeDamage(int damage)
  {
    currentHealth -= damage;
    
    healthBar.SetHealth(currentHealth);
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
