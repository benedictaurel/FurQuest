using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOne : MonoBehaviour
{
    public static CameraOne Instance { get; private set; }

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }
}
