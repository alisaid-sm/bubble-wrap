using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Clicker : MonoBehaviour
{
    public Camera cameraViewer;
    Camera m_Camera;
    void Awake()
    {
        m_Camera = Camera.main;
    }
    void Update()
    {
        Mouse mouse = Mouse.current;
        if (mouse.leftButton.wasPressedThisFrame)
        {
            Vector3 mousePosition = mouse.position.ReadValue();
            Ray ray = m_Camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.CompareTag("Point"))
                {
                    Debug.Log(hit.transform.name);
                    Transform camPos = hit.transform.Find("CameraPos");
                    cameraViewer.transform.SetParent(camPos);
                    cameraViewer.enabled = true;
                    cameraViewer.transform.position = camPos.transform.position;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cameraViewer.enabled = false;
        }
    }
}
