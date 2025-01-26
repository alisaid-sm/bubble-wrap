using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _computerScreen;

    [SerializeField]
    private GameObject _measurementScreen;
    [SerializeField]
    private GameObject _inputMeasurementScreen;
    [SerializeField]
    private GameObject _bubbleBuilderScreen;

    [SerializeField]
    public TMP_Text author;
    [SerializeField]
    public TMP_Text sentence;

    private GameDataManager gameDataManager;
    private DialogueTrigger dialogueTrigger;

    public List<ITask> _itemTasks;
    private GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        gameDataManager = GameObject.FindWithTag("GameDataManager").GetComponent<GameDataManager>();
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    void Start()
    {
        _itemTasks = gameDataManager.GenerateTask(10);
        gameManager.onDialog = true;
        dialogueTrigger.TriggerDialogue();
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

    public void OnBubbleBuilderEnter()
    {
        OnLeaveObject();
        gameManager.formMode = true;
        _bubbleBuilderScreen.SetActive(true);
    }

    public void OnLeaveObject()
    {
        _computerScreen.SetActive(false);
        _measurementScreen.SetActive(false);
        _inputMeasurementScreen.SetActive(false);
        gameManager.formMode = false;
    }

    public void OnEndDialog()
    {
        gameManager.Player.SetActive(true);
        gameManager.onDialog = false;
    }

    public ITask FindTask()
    {
        ITask task = _itemTasks.Find((task) => task.status == ITaskStatus.ON_PROGRESS);
        return task;
    }
}
