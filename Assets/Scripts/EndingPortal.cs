using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingPortal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.LevelManager.LoadScene("Main Menu");
        }
    }
}
