using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField]
    private GameDataManager m_GameDataManager;

    [SerializeField]
    private string m_SaveFileName = "savegame.dat";

    private PlayerDataDefinition _playerData;

    void Start()
    {
        LoadGame();
    }

    public PlayerDataDefinition NewGame()
    {
        m_GameDataManager.PlayerDataDefinition = m_GameDataManager.NewPlayerData();
        return m_GameDataManager.PlayerDataDefinition;
    }

    public void LoadGame()
    {
        Debug.Log("Load Game");
        _playerData = m_GameDataManager.PlayerDataDefinition;
        bool _isContinue = false;
        if (_playerData == null)
        {
            _playerData = NewGame();
        }
        else if (FileManager.LoadFromFile(m_SaveFileName, out var jsonString))
        {
            if (jsonString == "")
            {
                _playerData = NewGame();
            }
            else
            {
                string fixedString = jsonString;
                Debug.Log(fixedString);
                _playerData.LoadJson(fixedString);
                _isContinue = true;
            }
        }
        else
        {
            Debug.Log("Load File Failed");
            _playerData = NewGame();
        }
        Debug.Log(_isContinue == true ? "Load Game" : "New Game");
    }

    public void SaveGame()
    {
        string jsonFile = m_GameDataManager.PlayerDataDefinition.ToJson();

        FileManager.WriteToFile(m_SaveFileName, jsonFile);
    }

    void OnApplicationQuit()
    {
        SaveGame();
    }
}
