using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 1)]
public class GameData : ScriptableObject
{
    public HashSet<string> boardWords;
    public HashSet<string> playerWords;
    public int totalScore;
    public float wordsPerMinute;
    public float scorePerMinute;
    public int seedNumber;

    public void Initialize(HashSet<string> boardWords, HashSet<string> playerWords, int totalScore, float wordsPerMinute, float scorePerMinute, int seedNumber)
    {
        this.boardWords = new HashSet<string>(boardWords);
        this.playerWords = new HashSet<string>(playerWords);
        this.totalScore = totalScore;
        this.wordsPerMinute = wordsPerMinute;
        this.scorePerMinute = scorePerMinute;
        this.seedNumber = seedNumber;
    }
}
