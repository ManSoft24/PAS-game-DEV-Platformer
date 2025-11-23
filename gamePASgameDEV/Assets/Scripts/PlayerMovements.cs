using UnityEngine;
using System.Collections;
using NUnit.Framework;

public class playerMovements : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    public SpriteRenderer sr;

    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    public int maxJumps = 1;
    private int currentJumps;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // basic move code and Jumping

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (isGrounded)
            {
                moveSpeed = 9f;
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 5f;
        }

        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
            else if (currentJumps > 0)
            {

                currentJumps--; // ngurangin token jumping
                // 
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); //biar gaya nya gk numpuk
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
        }

        // flip sprite for animation

        if (moveInput != 0 && moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput != 0 && moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);

        }

        SetAnimation(moveInput);
    }

    private void FixedUpdate()
    {
        // ground checker

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);



        // to reset jumps when grounded

        if (isGrounded)
        {
            currentJumps = maxJumps;
        }
    }



    private void SetAnimation(float moveInput)
    {
        // animation
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.LeftShift) && moveInput != 0)
            {
                animator.SetBool("isRunning", true);
                animator.SetBool("isWalking", false);
            }
            else if (moveInput != 0)
            {
                animator.SetBool("isWalking", true);
                animator.SetBool("isRunning", false);
            }
            else if (moveInput == 0)
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", false);
            }
                animator.SetBool("isJumping", false);
                animator.SetBool("isFalling", false);
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
            if (rb.linearVelocity.y > 0)
            {
                animator.SetBool("isJumping", true);
                animator.SetBool("isFalling", false);
            }
            else
            {
                animator.SetBool("isFalling", true);
                animator.SetBool("isJumping", false);
            }
        }
    }

}