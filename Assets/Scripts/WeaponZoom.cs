using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] float zoomedOutFOV = 40f;
    [SerializeField] float zoomedInFov = 20f;
    [SerializeField] float zoomedInSensitivity;
    [SerializeField] float zoomedOutSensitivity;

    bool isZoomed;

    void Start()
    {
        virtualCamera.m_Lens.FieldOfView = zoomedOutFOV;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (isZoomed)
            {
                ExitZoom();
                isZoomed = false;
            }
            else
            {
                MakeZoom();
                isZoomed = true;
            }
        }
    }

    void MakeZoom()
    {
        virtualCamera.m_Lens.FieldOfView = zoomedInFov;
    }

    void ExitZoom()
    {
        virtualCamera.m_Lens.FieldOfView = zoomedOutFOV;
    }
}
