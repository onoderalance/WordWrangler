using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Assign a UI Text component in the Inspector
    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Increment the elapsed time
        timeElapsed += Time.deltaTime;

        // Calculate minutes, seconds, and milliseconds
        int minutes = Mathf.FloorToInt(timeElapsed / 60f);
        int seconds = Mathf.FloorToInt(timeElapsed % 60f);
        int milliseconds = Mathf.FloorToInt((timeElapsed * 1000f) % 1000f);

        // Update the UI text with the formatted time
        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
