//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using UnityEngine;

//[System.Serializable]

//public class ProfeJSON : MonoBehaviour
//{
//    public string playerName;
//    public int score;

//    void Awake()
//    {
//        filePath = Application.persistentDataPath + "/setting.json";

//    }

//    public void Save()
//    {
//        string jsonSetting = JsonUtility.ToJson(settings);
//        File.WriteAllText(filePath,JsonUtility.ToJson(settings));
//    }

//    public void Load()
//    {
//        //if File.Exists((filePath))
//        {
//            string jsonSetting = File.ReadAllText(filePath);
//            JsonUtility.FromJsonOverwrite(jsonSetting, settings);
//        }
//    }
//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
//public class TestSerialization
//{
//    public void SerializePlayerData()
//    {
//        PlayerData data = new PlayerData();
//        data.playerName = "Sergio";
//        data.score = 100;

//        //Converir a JSON
//        string json = JsonUtility.ToJson(data);
//        Debug.Log(json);

//        //Convertir de Json a objeto
//        PlayerData loadedData = JsonUtility.FromJson<PlayerData>(json);
//        Debug.Log("Player: " + loadedData.playerName + ", Score: " + loadedData.score);
//    }
//}
