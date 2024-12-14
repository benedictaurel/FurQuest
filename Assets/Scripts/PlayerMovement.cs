using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator animator;
    public Ladder ladder;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    [SerializeField] float speed = 2;
    [SerializeField] float jumpForce = 7;
    [SerializeField] float climbSpeed = 2;

    float groundCheckRadius = 0.2f;
    float horizontalMove;

    bool isFacingRight = true;
    bool isGrounded = false;
    bool killEnemy = false;
    public bool isKnockedBack = false;
    bool isDead = false;
    bool isClimbing = false;
    [HideInInspector] public bool canClimb = false;
    [HideInInspector] public bool bottomLadder = false;
    [HideInInspector] public bool topLadder = false;

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

            foreach(var c in colliders) {
                if (c.CompareTag("Platform")) {
                    transform.parent = c.transform;
                }
            }
        } else {
            transform.parent = null;
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

        if (canClimb && Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f) {
            Climb();
            animator.SetBool("isClimbing", true);
            animator.SetBool("Jump", false);
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            transform.position = new Vector3(ladder.transform.position.x, rb.position.y);
            rb.gravityScale = 0f;
        }

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
        if (isGrounded || killEnemy || isClimbing) {
            killEnemy = false;

            if (isClimbing) {
                ResetClimbingState();
            }

            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("Jump", true);
        }
    }

    void ResetClimbingState() {
        isClimbing = false;
        canClimb = false;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.gravityScale = 1f;
        animator.SetBool("isClimbing", false);
    }

    public void SetKillEnemy(bool value) {
        killEnemy = value;
    }

    void Climb() {
        isClimbing = true;
        if (Input.GetButtonDown("Jump")) {
            Jump();
            return;
        }

        float vDirection = Input.GetAxis("Vertical");

        if (vDirection > .1f && !topLadder) {
            animator.speed = 1f;
            rb.velocity = new Vector2(0f, vDirection * climbSpeed);
        } else if (vDirection < -.1f && !bottomLadder) {
            animator.speed = 1f;
            rb.velocity = new Vector2(0f, vDirection * climbSpeed);
        } else {
            animator.speed = 0f;
            rb.velocity = new Vector2(0, 0);
        }
    }
}
