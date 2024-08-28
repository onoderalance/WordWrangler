using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Assign a UI Text component in the Inspector
    public int score;
    public GameData gameData;

    // Start is called before the first frame update
    void Start()
    {
        //initialize score to 0
        score = 0;
        //update total score
        gameData.totalScore = score;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the UI text with the formatted score
        scoreText.text = "Score: " + score.ToString();
    }

    //grant points based on length of word
    public void addWord(string word)
    {
        int length = word.Length;
        int newVal = 0;

        //for length 3, only 100 points
        if (length == 3)
        {
            newVal = 100;
        }
        //otherwise, add 400 per word
        else
        {
            newVal = ((length - 3) * 400);
        }

        score += newVal;
        //update total score
        gameData.totalScore = score;
        gameData.scorePerMinute = score * 3 / 4;
    }
}
