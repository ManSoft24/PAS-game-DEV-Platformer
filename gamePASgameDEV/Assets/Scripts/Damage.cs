using UnityEngine;

public class Damage : MonoBehaviour
{

    public playerHealth pHealth;
    public float damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Damage script initialized.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Try to get the playerHealth component from the collided object
            playerHealth ph = other.gameObject.GetComponent<playerHealth>();

            if (ph != null)
            {
                ph.TakeDamage(damage);
                Debug.Log("Player took damage: " + damage + ". Current health: " + ph.health);
            }
            else if (pHealth != null)
            {
                // Fallback to the inspector-assigned reference if present
                pHealth.TakeDamage(damage);
                Debug.Log("Player took damage (fallback): " + damage + ". Current health: " + pHealth.health);
            }
            else
            {
                Debug.LogWarning("Damage: triggered by Player but no playerHealth component found and no fallback assigned.");
            }

            // Optional: destroy or disable this damage object after applying damage
            // Destroy(gameObject);
        }
    }
}
