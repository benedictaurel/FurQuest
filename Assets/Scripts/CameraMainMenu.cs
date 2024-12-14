using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMainMenu : MonoBehaviour
{
    public Transform[] positions;
    public float speed = 2;
    public int nextWaypoint = 0;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            LoadGame();
        }

        MoveToNextPoint();
    }
    
    void MoveToNextPoint() {
        Transform goalPoint = positions[nextWaypoint];
        
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        Vector3 newPosition = transform.position;
        newPosition.z = -10;
        transform.position = newPosition;
        
        if(Vector2.Distance(transform.position, goalPoint.position) < 1f) {
            if (nextWaypoint == positions.Length - 1) {
                nextWaypoint = 0;
            } else {
                nextWaypoint++;
            }
        }
    }

    void LoadGame() {
        SceneManager.LoadScene("LevelOne");
    }
}
