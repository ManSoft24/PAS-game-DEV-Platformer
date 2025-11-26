using System.Collections;
using System.Xml.Serialization;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    int maxHealth = 100;
    int currentHealth;
    public GameObject enemyObject;
    public GameObject mouse;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            mouse.SetActive(false);
            animator.SetBool("isDead", true);
            StartCoroutine(TimeBeforeDestroy());
        }
    }

    IEnumerator TimeBeforeDestroy()
    {
        yield return new WaitForSeconds(1.15f);
        enemyObject.SetActive(false);
    }
}
