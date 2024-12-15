using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDoor : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            DontDestroyOnLoad(other.gameObject);
            GameManager.Instance.LevelManager.LoadScene("LevelTwo");
        }
    }
}
