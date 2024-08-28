using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrolltextscript : MonoBehaviour
{
    public Text textComponent; public GameData gameData;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText(GameData.Instance.boardWords);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText(HashSet<string> words)
    {
        string text = string.Join("\n", words);
        textComponent.text = text;

        // Adjust the content size to fit all the text
        RectTransform contentRect = textComponent.GetComponent<RectTransform>();
        contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, textComponent.preferredHeight);
    }
}
