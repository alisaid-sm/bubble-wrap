using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class PlayerUpgrade
{
    public PlayerUpgrade(string id, int level)
    {
        this.id = id;
        this.level = level;
    }
    string id;
    int level;
}

[Serializable]
public class PlayerDataDefinition
{
    public string ID;
    public int gold;

    public List<PlayerUpgrade> upgrades;

    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public void LoadJson(string filePath)
    {
        JsonUtility.FromJsonOverwrite(filePath, this);
    }
}
