using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public int cherries = 3;
    public bool isDead = false;
    public Image[] lives;
    PlayerMovement playerMovement;
    FrogEnemies frogEnemies;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }

        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            TakeDamage();
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy")) {
            if (playerMovement.animator.GetFloat("yVelocity") < -1) {
                playerMovement.SetKillEnemy(true);
                playerMovement.Jump();
                
                if (other.gameObject.GetComponent<FrogEnemies>() != null) {
                    frogEnemies = other.gameObject.GetComponent<FrogEnemies>();
                    frogEnemies.animator.SetBool("isDead", true);
                }

                Destroy(other.gameObject, 0.5f);

                if (other.transform.parent != null) {
                    Destroy(other.transform.parent.gameObject);
                }
            } else {
                TakeDamage();

                if (other.gameObject.transform.position.x > transform.position.x) {
                    playerMovement.Knockback(true);
                } else {
                    playerMovement.Knockback(false);
                }
            }
        }
    }

    public void TakeDamage() {
        if (isDead)
            return;

        cherries--;
        lives[cherries].enabled = false;

        if (cherries <= 0) {
            isDead = true;
            FreezeTime();
            StartCoroutine(DelayedRestart());
        }
    }

    void FreezeTime() {
        Time.timeScale = 0f;
        
        Rigidbody2D[] allRigidbodies = FindObjectsOfType<Rigidbody2D>();
        foreach (Rigidbody2D rb in allRigidbodies) {
            rb.velocity = Vector2.zero;
            rb.simulated = false;
        }
    }

    void UnfreezeTime() {
        Time.timeScale = 1f;
        
        Rigidbody2D[] allRigidbodies = FindObjectsOfType<Rigidbody2D>();
        foreach (Rigidbody2D rb in allRigidbodies) {
            rb.simulated = true;
        }
    }

    IEnumerator DelayedRestart() {
        yield return new WaitForSecondsRealtime(1f);
        UnfreezeTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddCherry() {
        cherries++;
        cherries = Mathf.Clamp(cherries, 0, 3);
        lives[cherries - 1].enabled = true;
    }

    public int GetCherries() {
        return cherries;
    }
}
