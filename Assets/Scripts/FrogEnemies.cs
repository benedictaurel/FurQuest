using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogEnemies : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator animator;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    [SerializeField] float jumpForce = 7;
    [SerializeField] float moveSpeed = 3f;

    float groundCheckRadius = 0.2f;
    int changeValue;
    int jumpCount = 0;
    int maxJumps = 3;
    int facingDirection = -1;

    bool isGrounded = false;
    bool isIdle = false;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start() {
        animator.SetBool("isDead", false);
    }

    void FixedUpdate() {
        GroundCheck();
        if (!isIdle) {
            JumpToNextPoint();
        }

        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    void GroundCheck() {
        bool wasGrounded = isGrounded;
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayer);

        if (colliders.Length > 0) {
            isGrounded = true;

            if (!wasGrounded) {
                animator.SetBool("Jump", false);
            }
        }
    }

    IEnumerator IdleDelay() {
        isIdle = true;
        yield return new WaitForSeconds(5f);
        isIdle = false;
    }

    void JumpToNextPoint() {
        animator.SetBool("Jump", true);
        rb.velocity = new Vector2(moveSpeed * facingDirection, jumpForce);
        jumpCount++;

        if (jumpCount >= maxJumps) {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            facingDirection *= -1;
            jumpCount = 0;
        }

        StartCoroutine(IdleDelay());
    }
}
