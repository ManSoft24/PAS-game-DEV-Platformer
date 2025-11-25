using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float kecepatan = 2f;

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D Collision)
    {
        if(Collision.gameObject.CompareTag("Player"))
        {
        if (target == null) return;

        Vector2 arah = (target.position - transform.position).normalized;

        // PERBAIKAN DI SINI
        rb.linearVelocity = new Vector2(arah.x * kecepatan, rb.linearVelocity.y);

        // flip enemy sesuai arah
        if (arah.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (arah.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        animator.SetBool("isWalking",true);
  }
 }
}
