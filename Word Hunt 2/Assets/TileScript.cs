using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TileScript : MonoBehaviour
{
    public char letter;
    public TextMeshPro textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        letter = GetRandomLetter();
        UpdateLetterText();
    }

    // Update is called once per frame
    void Update()   
    {
        
    }

    void UpdateLetterText()
    {
        // Update the text with the current letter value
        textMeshPro.text = letter.ToString();
    }

    // Chooses a random letter A to Z
    public char GetRandomLetter()
    {
        int asciiValue = UnityEngine.Random.Range(65, 91); // ASCII values for 'A' (65) to 'Z' (90)
        return (char)asciiValue;
    }
}
