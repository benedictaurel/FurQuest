using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleEnemies : MonoBehaviour
{
    public bool isDead = false;
    public Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    public void Die() {
        isDead = true;
        animator.SetBool("isDead", true);
    }
}
