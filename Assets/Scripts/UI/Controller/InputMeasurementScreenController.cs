using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InputMeasurementScreenController : MonoBehaviour
{
    [SerializeField]
    private InputField inputPanjang;

    [SerializeField]
    private InputField inputLebar;

    [SerializeField]
    private InputField inputTinggi;

    [SerializeField]
    private Button _submitBtn;

    [SerializeField]
    private GameObject spawnPoint;

    private GameObject package;

    private GameManager gameManager;


    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        package = GameObject.FindWithTag("Package");
        gameManager.formMode = true;
        _submitBtn.onClick.AddListener(Submit);
    }

    public void ResetInput()
    {
        package = GameObject.FindWithTag("Package");
        inputPanjang.text = "";
        inputLebar.text = "";
        inputTinggi.text = "";
    }

    private void Submit()
    {
        int p = int.Parse(inputPanjang.text);
        int l = int.Parse(inputLebar.text);
        int t = int.Parse(inputTinggi.text);

        gameManager.SetPlayerForm(p, l, t);
        package.transform.SetParent(spawnPoint.transform);
        package.transform.position = spawnPoint.transform.position;
        package.transform.rotation = spawnPoint.transform.rotation;
    }
}