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
    [SerializeField] float zoomedInFOV = 20f;

    bool isZoomed;

    void Start()
    {
        virtualCamera.m_Lens.FieldOfView = zoomedOutFOV;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!isZoomed)
            {
                MakeZoom();
            }
            else
            {
                ExitZoom();
            }
        }
    }

    void MakeZoom()
    {
        virtualCamera.m_Lens.FieldOfView = zoomedInFOV;
        isZoomed = true;
    }

    void ExitZoom()
    {
        virtualCamera.m_Lens.FieldOfView = zoomedOutFOV;
        isZoomed = false;
    }

    private void OnDisable()
    {
        ExitZoom();
    }
}
