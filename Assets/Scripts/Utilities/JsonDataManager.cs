using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public static class JsonDataManager
{
    private static string filePath = Application.persistentDataPath + "/playerdata.json";

    public static void SaveData(PlayerData data)//Para guardar datos del player en JSON
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
        Debug.Log("Data saved to: " + filePath); // Añadir esto para verificar la ruta

    }

    public static PlayerData LoadData()//Para cargar datos del player desde el JSON
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            Debug.LogWarning("No player data file found."); // Avisar si no hay archivo
            return new PlayerData { playerName = "DefaultPlayer", highScore = 0 };
        }
    }

}
