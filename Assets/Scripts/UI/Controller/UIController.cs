using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
class Screen
{
    public string name;
    public GameObject screen;
}

public class UIController : MonoBehaviour
{
    [SerializeField]
    private List<Screen> screens;

    [SerializeField]
    private List<Screen> popups;

    [SerializeField]
    public GameObject mainBgm;

    private GameDataManager _gameDataManager;

    void Awake()
    {
        _gameDataManager = GameObject.FindWithTag("GameDataManager").GetComponent<GameDataManager>();
        mainBgm = GameObject.FindWithTag("BGM");
    }

    void Start()
    {
        LoadSettings();
    }
    private void LoadSettings()
    {
        AudioSource bgmAudio = mainBgm.GetComponent<AudioSource>();
        if (PlayerPrefs.GetString("muted") == "true")
        {
            bgmAudio.mute = true;
        }
        else
        {
            bgmAudio.mute = false;
        }
    }
    public void Route(string dest)
    {
        for (int i = 0; i < screens.Count; i++)
        {
            screens[i].screen.SetActive(false);
            if (screens[i].name == dest)
            {
                screens[i].screen.SetActive(true);
            }
        }
    }
    public void Popup(string dest)
    {
        for (int i = 0; i < popups.Count; i++)
        {
            popups[i].screen.SetActive(false);
            if (popups[i].name == dest)
            {
                popups[i].screen.SetActive(true);
            }
        }
    }


}
