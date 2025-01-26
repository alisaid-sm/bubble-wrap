using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _computerScreen;

    [SerializeField]
    private GameObject _measurementScreen;
    [SerializeField]
    private GameObject _inputMeasurementScreen;
    [SerializeField]
    public GameObject _bubbleBuilderScreen;
    [SerializeField]
    public GameObject _kirimScreen;

    [SerializeField]
    public GameObject _resultScreen;

    [SerializeField]
    public TMP_Text _messageText;

    [SerializeField]
    public TMP_Text author;
    [SerializeField]
    public TMP_Text sentence;
    public TMP_Text goldText;

    private GameDataManager gameDataManager;
    private DialogueTrigger dialogueTrigger;

    public List<ITask> _itemTasks;
    private GameManager gameManager;
    SaveManager saveManager;

    string message = "";

    void Awake()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        gameDataManager = GameObject.FindWithTag("GameDataManager").GetComponent<GameDataManager>();
        saveManager = GameObject.FindWithTag("SaveManager").GetComponent<SaveManager>();
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    void Start()
    {
        _itemTasks = gameDataManager.GenerateTask(10);
        gameManager.onDialog = true;
        dialogueTrigger.TriggerDialogue();
    }

    void Update()
    {
        goldText.text = gameDataManager.GetPlayerData().gold.ToString();
    }

    public void OnEnterComputer()
    {
        _computerScreen.SetActive(true);
        Transform child = _computerScreen.transform.Find("ListItem");
        child.GetComponent<ComputerScreenController>()?.RenderTasks();
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
        _inputMeasurementScreen.GetComponent<InputMeasurementScreenController>().ResetInput();
    }

    public void OnBubbleBuilderEnter()
    {
        OnLeaveObject();
        gameManager.formMode = true;
        _bubbleBuilderScreen.SetActive(true);
        _bubbleBuilderScreen.GetComponent<BubbleBuilderScreenController>()?.LoadResources();
        _bubbleBuilderScreen.GetComponent<BubbleBuilderScreenController>()?.RenderBubbleForm();
    }

    public void OnSubmitBubble()
    {
        _bubbleBuilderScreen.SetActive(false);
        gameManager.formMode = false;
        PlayerDataDefinition playerData = gameDataManager.PlayerDataDefinition;
        playerData.gold -= gameManager.bubbleForm.price;
        saveManager.SaveGame();
    }

    public void OnLeaveObject()
    {
        _computerScreen.SetActive(false);
        _measurementScreen.SetActive(false);
        _inputMeasurementScreen.SetActive(false);
        _bubbleBuilderScreen.SetActive(false);
        _kirimScreen.SetActive(false);
        _resultScreen.SetActive(false);

        gameManager.formMode = false;
    }

    public void OnKirimClose()
    {
        OnLeaveObject();
        GameObject[] packages = GameObject.FindGameObjectsWithTag("Package");
        foreach (GameObject obj in packages)
        {
            Destroy(obj);
        }
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

    public List<BubbleDefinition> GetBubbles()
    {
        return gameDataManager.GetBubbles();
    }

    public int GetPlayerGold()
    {
        return gameDataManager.GetPlayerData().gold;
    }

    public void Kirim()
    {
        ITask task = FindTask();
        int weight = task.package.weight;
        int volume = task.package.totalDimension;

        int orderVolume = gameManager.bubbleForm.maxVolume;
        int orderWeight = gameManager.bubbleForm.maxWeight;

        bool isSuccess = true;
        message = "Pengiriman Sukses";

        if (orderWeight < weight || orderVolume < volume)
        {
            isSuccess = false;
            message = "Pengiriman Gagal";
            task.status = ITaskStatus.FAILED;
        }

        if (isSuccess)
        {
            PlayerDataDefinition playerData = gameDataManager.PlayerDataDefinition;
            playerData.gold += task.package.price;
            gameDataManager.SetPlayerData(playerData);
            task.status = ITaskStatus.SUCCESS;
        }
        gameManager.SetBubbleForm(0, 0, 0);
        gameManager.SetPlayerForm(0, 0, 0);
        saveManager.SaveGame();
        _kirimScreen.SetActive(false);
        _resultScreen.SetActive(true);
        _messageText.text = message;

    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }


}
