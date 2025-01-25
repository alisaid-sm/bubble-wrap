using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Clicker : MonoBehaviour
{
    public Camera cameraViewer;
    public GameObject rulerHorizontal;
    public GameObject rulerVertical;
    Camera m_Camera;
    GameManager gameManager;
    private Point _pointSelected;

    void Awake()
    {
        m_Camera = Camera.main;
        gameManager = GetComponent<GameManager>();
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
                if (hit.transform.CompareTag("Point") && !_pointSelected)
                {
                    _pointSelected = hit.transform.GetComponent<Point>();
                    Transform camPos = hit.transform.Find("CameraPos");
                    cameraViewer.enabled = true;
                    cameraViewer.transform.position = camPos.transform.position;
                    cameraViewer.transform.rotation = camPos.transform.rotation;
                    gameManager.Player.transform.position = new Vector3(0, gameManager.Player.transform.position.y, -1);
                    gameManager.Player.transform.rotation = new Quaternion(0,0,0,0);
                    gameManager.viewerMode = true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_pointSelected)
            {
                cameraViewer.enabled = false;
                gameManager.viewerMode = false;
                _pointSelected.transform.rotation = new Quaternion(0,0,0,0);
                _pointSelected = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Rotate left");
            if (_pointSelected && _pointSelected.canRotate)
            {
                _pointSelected.transform.Rotate(new Vector3(_pointSelected.transform.rotation.x, _pointSelected.transform.rotation.y + 10f, _pointSelected.transform.rotation.z));
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Rotate right");
            if (_pointSelected && _pointSelected.canRotate)
            {
                _pointSelected.transform.Rotate(new Vector3(_pointSelected.transform.rotation.x, _pointSelected.transform.rotation.y - 10f, _pointSelected.transform.rotation.z));
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Activate ruler");
            if (!rulerHorizontal.activeSelf && !rulerVertical.activeSelf)
            {
                rulerHorizontal.SetActive(true);
            }
            else if (!rulerVertical.activeSelf)
            {
                rulerHorizontal.SetActive(false);
                rulerVertical.SetActive(true);
            }
            else
            {
                rulerVertical.SetActive(false);
            }
        }
    }
}
