using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroScreenController : MonoBehaviour
{
    [SerializeField]
    private Button _startBtn, _creditBtn, _quitBtn, _volBtn;

    void Awake()
    {
        _startBtn.onClick.AddListener(OnStartClick);
        _creditBtn.onClick.AddListener(OnCreditClick);
        _quitBtn.onClick.AddListener(OnQuitClick);
        _volBtn.onClick.AddListener(OnVolClick);
    }

    private void OnVolClick()
    {
        Debug.Log("OK");
    }

    private void OnQuitClick()
    {
        Application.Quit();
    }

    private void OnCreditClick()
    {
        Debug.Log("OK");
    }

    private void OnStartClick()
    {
        Debug.Log("OK");
    }
}
