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
