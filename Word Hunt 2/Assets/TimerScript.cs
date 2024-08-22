using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Assign a UI Text component in the Inspector
    private float timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        //initialize the time to 80 seconds
        timeRemaining = 80f;
    }

    // Update is called once per frame
    void Update()
    {
        // Decrement the elapsed time
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }

        // Calculate minutes, seconds, and milliseconds
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        int milliseconds = Mathf.FloorToInt((timeRemaining * 1000f) % 1000f);

        // Update the UI text with the formatted time
        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

        //When time is out, go to post-game screen
        if(timeRemaining <= 0)
        {
            SceneManager.LoadScene("postgamescene");   
        }
        
    }
}
