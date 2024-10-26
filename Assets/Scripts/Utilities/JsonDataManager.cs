using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public static class JsonDataManager
{
    private static string filePath = Application.persistentDataPath + "/playerdata.json";

    public static void SaveData(PlayerData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
        Debug.Log("Data saved to: " + filePath);

    }

    public static PlayerData LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            Debug.LogWarning("No player data file found.");
            return new PlayerData { playerName = "DefaultPlayer", highScore = 0 };
        }
    }

}
