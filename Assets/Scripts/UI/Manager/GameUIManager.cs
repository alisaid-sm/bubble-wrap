using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _computerScreen;

    [SerializeField]
    private GameObject _measurementScreen;
    [SerializeField]
    private GameObject _inputMeasurementScreen;

    private GameDataManager gameDataManager;

    public List<ITask> _itemTasks;
    private GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        gameDataManager = GameObject.FindWithTag("GameDataManager").GetComponent<GameDataManager>();
    }

    void Start()
    {
        _itemTasks = gameDataManager.GenerateTask(10);
    }



    public void OnEnterComputer()
    {
        _computerScreen.SetActive(true);
    }
    public void OnEnterMeasurement()
    {
        _measurementScreen.SetActive(true);
    }

    public void OnInputMeasurement()
    {
        OnLeaveObject();
        gameManager.formMode = true;
        _inputMeasurementScreen.SetActive(true);
    }

    public void OnLeaveObject()
    {
        _computerScreen.SetActive(false);
        _measurementScreen.SetActive(false);
        _inputMeasurementScreen.SetActive(false);
        gameManager.formMode = false;

    }
}
