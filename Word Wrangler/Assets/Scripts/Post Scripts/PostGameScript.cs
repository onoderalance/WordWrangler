using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class PostGameScript : MonoBehaviour
{
    public GameData gameData;
    private TextMeshProUGUI tlText;

    public GameObject wordTextPrefab; 
    public Transform contentTransform; 

    // Start is called before the first frame update
    void Start()
    {
        DisplayWords();
        GameObject tlTextObject = GameObject.FindWithTag("TLText");
        if (tlTextObject != null)
        {
            tlText = tlTextObject.GetComponent<TextMeshProUGUI>();
        }

        if (tlText != null && gameData != null)
        {
            int boardWordsCount = gameData.boardWords.Count;
            int playerWordsCount = gameData.playerWords.Count;
            int totalScore = gameData.totalScore;
            float wordsPerMinute = gameData.wordsPerMinute;
            float scorePerMinute = gameData.scorePerMinute;

            string displayText = $"Statistics: \n" + "\n" + 
                                 $"Total Words on Board: {boardWordsCount}\n" +
                                 $"Words Found: {playerWordsCount}\n" +
                                 $"Total Score: {totalScore}\n" +
                                 $"Words Per Minute: {wordsPerMinute:F2}\n" +
                                 $"Score Per Minute: {scorePerMinute}";

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

    void DisplayWords()
    {
        List<string> boardWords = gameData.boardWords.ToList();
        HashSet<string> playerWords = gameData.playerWords;

        // Sort the words
        var sortedWords = boardWords
            .OrderByDescending(word => word.Length) // sort by word length
            .ThenByDescending(word => playerWords.Contains(word)) // then by player found status
            .ThenBy(word => word) // then alphabetically
            .ToList();

        foreach (var word in sortedWords)
        {
            GameObject wordTextObj = Instantiate(wordTextPrefab, contentTransform);
            TextMeshProUGUI wordText = wordTextObj.GetComponent<TextMeshProUGUI>();

            wordText.text = word;

            if (playerWords.Contains(word))
            {
                wordText.color = Color.green;
            }
        }
    }
}
