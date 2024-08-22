using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class postgamescript : MonoBehaviour
{
    public GameData gameData;
    private TextMeshProUGUI tlText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject tlTextObject = GameObject.FindWithTag("TLText");
        if (tlTextObject != null)
        {
            tlText = tlTextObject.GetComponent<TextMeshProUGUI>();
        }

        if (tlText != null && gameData != null)
        {
            int boardWordsCount = gameData.boardWords.Count;
            int totalScore = gameData.totalScore;
            float wordsPerMinute = gameData.wordsPerMinute;
            float scorePerMinute = gameData.scorePerMinute;

            string displayText = $"Board Words: {boardWordsCount}\n" +
                                 $"Total Score: {totalScore}\n" +
                                 $"Words Per Minute: {wordsPerMinute:F2}\n" +
                                 $"Score Per Minute: {scorePerMinute:F2}";

            tlText.text = displayText;
        }
        else
        {
            Debug.LogError("GameData instance not found.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
