using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 1)]
public class GameData : ScriptableObject
{
    private static GameData _instance;

    public static GameData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<GameData>("GameData");
            }
            return _instance;
        }
    }

    public HashSet<string> boardWords;
    public HashSet<string> playerWords;
    public int totalScore;
    public int seedNumber;
    public float wordsPerMinute;
    public int scorePerMinute;

    // Method to clear the data (useful when starting a new game)
    public void ClearData()
    {
        boardWords = new HashSet<string>();
        playerWords = new HashSet<string>();
        totalScore = 0;
        seedNumber = 0;
        wordsPerMinute = 0f;
        scorePerMinute = 0;
    }
}

