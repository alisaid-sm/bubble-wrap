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
    public Animator pumpAnim;
    Camera m_Camera;
    GameManager gameManager;
    GameUIManager gameUIManager;
    private Point _pointSelected;
    private int _pumpAnimHash;

    void Awake()
    {
        m_Camera = Camera.main;
        gameManager = GetComponent<GameManager>();
        gameUIManager = GameObject.FindWithTag("GameUIManager").GetComponent<GameUIManager>();
        _pumpAnimHash = Animator.StringToHash("Pump");
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
                    //gameManager.Player.transform.position = new Vector3(0, gameManager.Player.transform.position.y, -1);
                    gameManager.Player.transform.rotation = new Quaternion(0, 0, 0, 0);
                    gameManager.Player.SetActive(false);
                    gameManager.viewerMode = true;
                    OnChangeObjectSelected();
                }
            }

            Ray rayViewer = cameraViewer.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(rayViewer, out RaycastHit hitViewer))
            {
                if (hitViewer.transform.CompareTag("Pump"))
                {
                    Debug.Log("Pump Bubble");
                    Package pkg = GameObject.FindGameObjectWithTag("Package").GetComponent<Package>();

                    if (pkg.bubble.localScale.x < pkg.bubbleMaxScale)
                    {
                        pumpAnim.SetTrigger(_pumpAnimHash);
                        float bubbleScalePer10 = pkg.bubbleMaxScale / 10;
                        float bubbleScale = pkg.bubble.localScale.x > 0 ? pkg.bubble.localScale.x + bubbleScalePer10 : bubbleScalePer10;
                        pkg.bubble.localScale = new Vector3(bubbleScale, bubbleScale, bubbleScale);
                    }
                }
            }
        }

        if (!gameManager.formMode && !gameManager.onDialog)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_pointSelected)
                {
                    OnEscapingObject();
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
        else
        {
            if (rulerHorizontal.activeSelf || rulerVertical.activeSelf)
            {
                rulerHorizontal.SetActive(false);
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
        if (_pointSelected.pointName == PointName.Measurement)
        {
            gameUIManager.OnEnterMeasurement();
        }
    }

    public void OnEscapingObject()
    {
        cameraViewer.enabled = false;
        gameManager.viewerMode = false;
        gameManager.Player.SetActive(true);
        _pointSelected.transform.rotation = new Quaternion(0, 0, 0, 0);
        _pointSelected = null;
        OnLeaveObject();
    }

    void OnLeaveObject()
    {
        gameUIManager.OnLeaveObject();
    }


}
