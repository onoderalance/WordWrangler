using UnityEngine;
using System.IO;

public class SaveSystem
{
    public void SaveData(SaveData data)
    {
        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/savedata.json";
        File.WriteAllText(path, json);
        Debug.Log("Data saved to: " + path);
    }

    public SaveData LoadData()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("Data loaded from: " + path);
            return data;
        }
        else
        {
            Debug.LogWarning("Save file not found at: " + path);
            return null;
        }
    }
}
