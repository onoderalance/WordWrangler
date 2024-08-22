using System;
using System.Collections.Generic;

[Serializable]
public struct GameRecord
{
    public HashSet<string> boardWords;
    public HashSet<string> playerWords;
    public int totalScore;
    public int seedNumber;
    public float wordsPerMinute;
    public float scorePerMinute;
    public int time;

    // Updated constructor
    public GameRecord(
        HashSet<string> boardWords,
        HashSet<string> playerWords,
        int totalScore,
        int seedNumber,
        float wordsPerMinute,
        float scorePerMinute,
        int time)
    {
        this.boardWords = boardWords;
        this.playerWords = playerWords;
        this.totalScore = totalScore;
        this.seedNumber = seedNumber;
        this.wordsPerMinute = wordsPerMinute;
        this.scorePerMinute = scorePerMinute;
        this.time = time;
    }
}
