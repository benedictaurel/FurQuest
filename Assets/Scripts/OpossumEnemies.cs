using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumEnemies : Enemy
{
    public Animator animator;

    int changeValue = 1;
    public int nextWaypoint = 0;
    public float speed = 2;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        MoveToNextPoint();
    }
    
    void MoveToNextPoint() {
        Transform goalPoint = points[nextWaypoint];
        
        if (goalPoint.transform.position.x > transform.position.x) {
            transform.localScale = new Vector3(-1, 1, 1);
        }else {
            transform.localScale = new Vector3(1, 1, 1);
        }
        
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        
        if(Vector2.Distance(transform.position, goalPoint.position) < 1f) {
            if (nextWaypoint == points.Count - 1) {
                changeValue = -1;
            } else if (nextWaypoint == 0) {
                changeValue = 1;
            }

            nextWaypoint += changeValue;
        }
    }

    public void Die() {
        animator.SetBool("isDead", true);
        speed = 0;
    }
}
