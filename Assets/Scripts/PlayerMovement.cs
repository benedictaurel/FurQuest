using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator animator;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    [SerializeField] float speed = 2;
    [SerializeField] float jumpForce = 7;

    float groundCheckRadius = 0.2f;
    float horizontalMove;

    bool isFacingRight = true;
    bool isGrounded = false;
    bool killEnemy = false;
    bool isKnockedBack = false;
    bool isDead = false;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (isDead) return;

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

    public void Knockback(bool isRight) {
        animator.SetBool("isHurt", true);
        isKnockedBack = true;
        if (isRight) {
            rb.velocity = new Vector2(-2f, rb.velocity.y);
        } else {
            rb.velocity = new Vector2(2f, rb.velocity.y);
        }
        StartCoroutine(ResetKnockback());
    }

    IEnumerator ResetKnockback() {
        yield return new WaitForSeconds(1.5f);
        isKnockedBack = false;
        animator.SetBool("isHurt", false);
    }

    void Move(float move) {
        if (isKnockedBack) return;

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

    public void Jump() {
        if (isGrounded || killEnemy) {
            killEnemy = false;
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("Jump", true);
        }
    }

    public void SetKillEnemy(bool value) {
        killEnemy = value;
    }
}
