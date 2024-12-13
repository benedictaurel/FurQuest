using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    [SerializeField] float speed = 2;
    [SerializeField] float jumpForce = 7;

    float groundCheckRadius = 0.2f;
    float horizontalMove;

    bool isFacingRight = true;
    bool isGrounded = false;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        horizontalMove = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump")) {
            Jump();
        }
        
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    void FixedUpdate() {
        GroundCheck();
        Move(horizontalMove);
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

    void Move(float move) {
        float xVal = move * speed * 100 * Time.fixedDeltaTime;
        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
        rb.velocity = targetVelocity;

        if (move > 0 && !isFacingRight) {
            transform.localScale = new Vector3(1, 1, 1);
            isFacingRight = true;
        } else if (move < 0 && isFacingRight) {
            transform.localScale = new Vector3(-1, 1, 1);
            isFacingRight = false;
        }

        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
    }

    void Jump() {
        if (isGrounded) {
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("Jump", true);
        }
    }
}
