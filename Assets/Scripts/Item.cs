using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    void Reset() {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (other.GetComponent<Player>().GetCherries() < 3) {
                other.GetComponent<Player>().AddCherry();
            }
            animator.SetBool("isPicked", true);
            Destroy(gameObject, 1f);
        }
    }
}