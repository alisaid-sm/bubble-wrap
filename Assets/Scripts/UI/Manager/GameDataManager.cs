using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    [SerializeField]
    private PlayerDataDefinition _playerData;

    [SerializeField]
    private List<UpgradeStats> _upgradeStats;

    public PlayerDataDefinition PlayerDataDefinition { set => _playerData = value; get => _playerData; }

    public PlayerDataDefinition NewPlayerData()
    {
        _playerData.ID = Guid.NewGuid().ToString();
        _playerData.coin = 500;
        _playerData.upgrades = new List<PlayerUpgrade>();
        for (int i = 0; i < _upgradeStats.Count; i++)
        {
            _playerData.upgrades.Add(new PlayerUpgrade(_upgradeStats[i].ID, 0));
        }
        return _playerData;
    }
}
