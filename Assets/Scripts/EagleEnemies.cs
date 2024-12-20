using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleEnemies : MonoBehaviour
{
    public Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    public void Die() {
        animator.SetBool("isDead", true);
    }
}
