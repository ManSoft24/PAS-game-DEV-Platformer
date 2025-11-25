using System.Xml.Serialization;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    int maxHealth = 100;
    int currentHealth;
    public GameObject enemyObject;

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
           enemyObject.SetActive(false);
        }
    }
}
