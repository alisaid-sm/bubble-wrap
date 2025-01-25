using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerForm
{
    public PlayerForm(int p, int l, int t)
    {
        this.panjang = p;
        this.lebar = l;
        this.tinggi = t;
    }
    public int panjang;
    public int lebar;
    public int tinggi;
}


public class GameManager : MonoBehaviour
{
    public GameObject Player;

    public PlayerForm playerForm;
    public bool viewerMode = false;

    public bool formMode = false;

    public void SetPlayerForm(int p, int l, int t)
    {
        playerForm = new PlayerForm(p, l, t);
    }
}
