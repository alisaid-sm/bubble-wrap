using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

[Serializable]
public enum ITaskStatus { STAND_BY, ON_PROGRESS, DONE }

[Serializable]
public class ITask
{
    public ITask(ClientDefinition client, PackageDefinition package)
    {
        this.ID = Guid.NewGuid().ToString();
        this.client = client;
        this.package = package;
        this.status = ITaskStatus.STAND_BY;
    }
    public string ID;
    public ClientDefinition client;
    public PackageDefinition package;
    public ITaskStatus status;
}

public class GameDataManager : MonoBehaviour
{
    [SerializeField]
    private PlayerDataDefinition _playerData;

    [SerializeField]
    private List<UpgradeStats> _upgradeStats;

    [SerializeField]
    private List<ClientDefinition> _clients;

    [SerializeField]
    private List<PackageDefinition> _packages;


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

    public List<ClientDefinition> GetClients()
    {
        return _clients;
    }

    public List<PackageDefinition> GetPackages()
    {
        return _packages;
    }

    public ClientDefinition RandomClient()
    {
        List<ClientDefinition> clients = GetClients();
        int randomIndex = UnityEngine.Random.Range(0, clients.Count);
        return clients[randomIndex];
    }
    public PackageDefinition RandomPackage()
    {
        List<PackageDefinition> packages = GetPackages();
        int randomIndex = UnityEngine.Random.Range(0, packages.Count);
        return packages[randomIndex];
    }

    public List<ITask> GenerateTask(int items = 1)
    {
        List<ITask> _randomTasks = new List<ITask>();
        for (int i = 0; i < items; i++)
        {
            _randomTasks.Add(new ITask(RandomClient(), RandomPackage()));
        }
        return _randomTasks;
    }
}
