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
[Serializable]
public class BubbleForm
{
    public BubbleForm(int v, int w, int p)
    {
        this.maxVolume = v;
        this.maxWeight = w;
        this.price = p;
    }
    public int maxVolume;
    public int maxWeight;
    public int price;
}


public class GameManager : MonoBehaviour
{
    public GameObject Player;

    public PlayerForm playerForm;
    public BubbleForm bubbleForm;
    public bool viewerMode = false;
    public bool formMode = false;
    public bool onDialog = false;

    public void SetPlayerForm(int p, int l, int t)
    {
        playerForm = new PlayerForm(p, l, t);
    }

    public void SetBubbleForm(int v, int w, int p)
    {
        bubbleForm = new BubbleForm(v, w, p);
    }
}
