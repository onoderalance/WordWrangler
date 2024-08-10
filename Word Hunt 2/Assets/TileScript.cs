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
        letter = 'c';
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
}
