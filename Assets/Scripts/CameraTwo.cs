using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraTwo : MonoBehaviour
{
    CinemachineVirtualCamera vcam;

    void Awake() {
        vcam = GetComponent<CinemachineVirtualCamera>();
        vcam.m_Follow = GameObject.Find("Player").transform;
    }
}
