using UnityEngine;
// using UnityEngine.SceneManagement; // kalau mau restart scene saat mati

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    public SpriteRenderer sr;
    public playerHealth pHealth;

    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;

    public int maxJumps = 1;
    private int currentJumps;

    public float deathY = -30f;      // batas kematian diganti jadi -30
    public Vector2 respawnPoint;     // tempat respawn player

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // set titik respawn awal
        respawnPoint = transform.position;
        currentJumps = maxJumps;

        // Initialize player health component if available
        if (pHealth == null)
            pHealth = GetComponent<playerHealth>();

        if (pHealth != null)
            pHealth.health = pHealth.maxHealth;
    }

    void Update()
    {
        // === CEK MATI KARENA TERJATUH ===
        if (transform.position.y < deathY)
        {
            Die();
            
        }

        // === MOVEMENT ===
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // === JUMPING ===
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
            else if (currentJumps > 0)
            {
                currentJumps--;
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
        }

        // === FLIP SPRITE ===
        if (moveInput > 0.01f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < -0.01f)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        // === ANIMASI ===
        SetAnimation(moveInput);
    }

    private void FixedUpdate()
    {
        // === CEK TANAH ===
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            currentJumps = maxJumps;
        }
    }

    private void SetAnimation(float moveInput)
    {
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
            if (rb.linearVelocity.y > 0)
                animator.Play("Jumping");
            else
                animator.Play("Falling");
        }
    }

    // === FUNGSI MATI / RESPAWN ===
    void Die()
    {
        Debug.Log("Player Mati Karena Jatuh!");

        // respawn player
        transform.position = respawnPoint;
        // kalau mau restart scene:
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
