using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;

public class SaveSystem
{
    [Serializable]
    public class SaveData
    {
        //testing variables
        public int lastSeed;
        public List<int> seeds;
        //main list of records
        public List<GameRecord> games;

        // Constructor to initialize lists
        public SaveData()
        {
            seeds = new List<int>();
            games = new List<GameRecord>();
        }
    }

    private SaveData currentData;

    //basic constructor
    public SaveSystem()
    {
        // Load data when SaveSystem is instantiated
        currentData = LoadData() ?? new SaveData();
    }

    public void UpdateSeed(int newSeed)
    {
        currentData.lastSeed = newSeed;
        currentData.seeds.Add(newSeed);
        WriteData();
    }

    public void AddRecord(GameRecord record)
    {
        currentData.games.Add(record);
        WriteData();
    }


    //write data to jason
    public void WriteData()
    {
        string json = JsonUtility.ToJson(currentData);
        string path = Application.persistentDataPath + "/savedata.json";
        File.WriteAllText(path, json);
        Debug.Log("Data saved to: " + path);
    }

    //load data from json
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
