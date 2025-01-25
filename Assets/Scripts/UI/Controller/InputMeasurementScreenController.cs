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

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        gameManager.formMode = true;
        _submitBtn.onClick.AddListener(Submit);
    }

    private void Submit()
    {
        int p = int.Parse(inputPanjang.text);
        int l = int.Parse(inputLebar.text);
        int t = int.Parse(inputTinggi.text);

        gameManager.SetPlayerForm(p, l, t);
    }
}