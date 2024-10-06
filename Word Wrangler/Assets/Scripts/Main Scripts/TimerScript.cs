using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Assign a UI Text component in the Inspector
    private float timeRemaining;
    public PlayerScript playerScript;

    //constant for game time (usually will be 80f, but 10f for testing)
    public float gameLength = 80f;

    // Start is called before the first frame update
    void Start()
    {
        if (StartScript.debugStart == true)
        {
            gameLength = 10f;
        }
        //initialize the time to gameLength seconds
        timeRemaining = gameLength;
    }

    // Update is called once per frame
    void Update()
    {
        // Decrement the elapsed time
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }

        // Ensure time doesn't go below 0
        timeRemaining = Mathf.Max(0, timeRemaining);

        // Calculate minutes, seconds, and milliseconds
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        int milliseconds = Mathf.FloorToInt((timeRemaining * 1000f) % 1000f);

        // Update the UI text with the formatted time
        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

        //When time is out, go to post-game screen
        if(timeRemaining <= 0)
        {
            //save player hashset
            playerScript.saveFoundWords();
            //load next scene
            SceneManager.LoadScene("postgamescene");   
        }
        
    }
}
