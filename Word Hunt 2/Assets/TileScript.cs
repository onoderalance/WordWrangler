using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TileScript : MonoBehaviour
{
    public char letter;
    public bool isSelected;
    public int posX;
    public int posY;
    public TextMeshPro textMeshPro;

    private SpriteRenderer spriteRenderer;
    public Sprite spriteDefault;
    public Sprite spriteSelected;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteDefault;
        letter = GetRandomLetter();
        Debug.Log($"Assigned Letter: {letter}");
        UpdateLetterText();
    }

    // Update is called once per frame
    void Update()   
    {
        
    }

    public void SetPosition(int x, int y)
    {
        posX = x;
        posY = y;
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

    public char GetLetter()
    {
        return letter;
    }
    public void UnSelect()
    {
        isSelected = false;
        spriteRenderer.sprite = spriteDefault;
    }

    public void Select()
    {
        isSelected = true;
        spriteRenderer.sprite = spriteSelected;
    }
}
