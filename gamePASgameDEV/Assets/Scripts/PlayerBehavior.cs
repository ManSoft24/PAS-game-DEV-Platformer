using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    int maxHealth = 100;
    int currentHealth;
    public Healthbar healthBar;
    private float attackDelay = 1f;
    private bool onCooldown = false;
    private Animator animator;
    Enemy enemy;
    int playerDamage = 40;
    Collider2D playercollision;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    [SerializeField] private GameObject deadScreen;

    void Awake()
    {
        StartGame();
        animator = GetComponent<Animator>();
        playercollision = GetComponent<Collider2D>();
    }

    void StartGame()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        transform.position = new Vector3(20, -2, 0);
    }


    void Update()
    {

        if (currentHealth <= 0 && !playercollision.gameObject.CompareTag("Void"))
        {
            die();
            if (Input.GetKeyDown(KeyCode.R))
            {
                restartGame();
            }
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
            else
            {
                Time.timeScale = 0f;
                deadScreen.SetActive(true);
                if (Input.GetKeyDown(KeyCode.R))
                {
                    restartGame();
                }
            }
        }
    }

    void Attack()
    {
        if (onCooldown == false)
        {
            animator.SetTrigger("Attack1");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(playerDamage);
                StartCoroutine(AttackCooldown());
            }


        }

        void OnDrawGizmosSelected()
        {
            if (attackPoint == null)
            {
                return;
            }

            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
        }

    public IEnumerator AttackCooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(attackDelay);
        onCooldown = false;
    }
}