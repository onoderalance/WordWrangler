using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public HashSet<string> validWords;

    // Start is called before the first frame update
    void Awake()
    {
        LoadWords();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadWords()
    {
        TextAsset wordFile = Resources.Load<TextAsset>("words");
        validWords = new HashSet<string>();
        string[] words = wordFile.text.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            validWords.Add(word);
        }
        Debug.Log($"Loaded {validWords.Count} words.");
    }

    // Method to check if a word is valid
    public bool isWordValid(string word)
    {
        return validWords.Contains(word.ToUpper());
    }
}