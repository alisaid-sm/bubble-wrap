using System;
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
    GameUIManager gameUIManager;
    private Point _pointSelected;

    void Awake()
    {
        m_Camera = Camera.main;
        gameManager = GetComponent<GameManager>();
        gameUIManager = GameObject.FindWithTag("GameUIManager").GetComponent<GameUIManager>();
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
                    gameManager.Player.transform.rotation = new Quaternion(0, 0, 0, 0);
                    gameManager.viewerMode = true;
                    OnChangeObjectSelected();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_pointSelected)
            {
                cameraViewer.enabled = false;
                gameManager.viewerMode = false;
                _pointSelected.transform.rotation = new Quaternion(0, 0, 0, 0);
                _pointSelected = null;
                OnLeaveObject();
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Rotate left");
            if (_pointSelected && _pointSelected.canRotate)
            {
                _pointSelected.packagePosition.transform.Rotate(new Vector3(_pointSelected.packagePosition.transform.rotation.x, _pointSelected.packagePosition.transform.rotation.y + 10f, _pointSelected.packagePosition.transform.rotation.z));
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Rotate right");
            if (_pointSelected && _pointSelected.canRotate)
            {
                _pointSelected.packagePosition.transform.Rotate(new Vector3(_pointSelected.packagePosition.transform.rotation.x, _pointSelected.packagePosition.transform.rotation.y - 10f, _pointSelected.packagePosition.transform.rotation.z));
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

    void OnChangeObjectSelected()
    {
        if (_pointSelected.pointName == PointName.Computer)
        {
            gameUIManager.OnEnterComputer();
        }
    }

    void OnLeaveObject()
    {
        gameUIManager.OnLeaveObject();
    }


}
