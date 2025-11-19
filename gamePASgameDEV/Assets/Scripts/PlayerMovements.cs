using UnityEngine;
// using UnityEngine.SceneManagement; // uncomment kalau mau restart scene saat mati

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    public SpriteRenderer sr;

    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    public int maxJumps = 1;
    private int currentJumps;

    public float deathY = -5f;
    public Vector2 respawnPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = sr == null ? GetComponent<SpriteRenderer>() : sr; // ambil SpriteRenderer kalau belum di-assign

        if (rb == null)
            Debug.LogWarning("Rigidbody2D belum ada di GameObject ini!");
        if (animator == null)
            Debug.LogWarning("Animator belum ada di GameObject ini!");
        if (groundCheck == null)
            Debug.LogWarning("groundCheck belum di-assign!");

        respawnPoint = transform.position; // set initial respawn point
        currentJumps = maxJumps;
    }

    void Update()
    {
        // ========== CEK MATI TERJATUH ==========
        if (transform.position.y < deathY)
        {
            Die();
            // return; // opsional, kalau mau hentikan update setelah mati
        }
        // =======================================

        // basic move code and Jumping
        float moveInput = Input.GetAxis("Horizontal");

        // pastikan rb tidak null sebelum set velocity
        if (rb != null)
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                if (rb != null) rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else if (currentJumps > 0)
            {
                currentJumps--; // ngurangin token jumping
                if (rb != null)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0f); // reset y supaya tidak numpuk
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                }
            }
        }

        // flip sprite for animation
        if (moveInput > 0.01f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < -0.01f)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        SetAnimation(moveInput);
    }

    private void FixedUpdate()
    {
        // ground checker (cek null juga)
        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }
        else
        {
            isGrounded = false;
        }

        // to reset jumps when grounded
        if (isGrounded)
        {
            currentJumps = maxJumps;
        }
    }

    private void SetAnimation(float moveInput)
    {
        // animation
        if (animator == null) return;

        if (isGrounded)
        {
            if (Mathf.Abs(moveInput) > 0.01f)
            {
                animator.Play("walking");
            }
            else
            {
                animator.Play("Idle");
            }
        }
        else
        {
            if (rb != null && rb.velocity.y > 0f)
            {
                animator.Play("Jumping");
            }
            else
            {
                animator.Play("Falling");
            }
        }
    }

    // ======== FUNGSI MATI / RESPAWN ==========
    void Die()
    {
        Debug.Log("Player Mati Karena Jatuh!");

        // respawn di titik yang diset (default posisi awal)
        transform.position = respawnPoint;

        // jika mau restart scene, uncomment 2 baris ini:
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // ========================================
}
