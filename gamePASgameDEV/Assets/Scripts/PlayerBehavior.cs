using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    int maxHealth = 100;
    int currentHealth;
    public Healthbar healthBar;
    public float attackDelay = 0.5f;
    private bool onCooldown;
    private Animator animator;
    [SerializeField] private GameObject deadScreen;

    void Awake()
    {
        StartGame();
        animator = GetComponent<Animator>();
    }

    void StartGame()
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
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            restartGame();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
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

    void Attack()
  {
    if (!onCooldown)
    {
        return;
    }
    else
    {
    animator.SetTrigger("Attack");
    onCooldown = true;
    StartCoroutine(AttackCooldown());
    }
  }

  public IEnumerator AttackCooldown()
  {
    yield return new WaitForSeconds(attackDelay);
    onCooldown = false;
  }
}