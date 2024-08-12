using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public string currentWord;
    public bool buildingWord;
    ManagerScript managerScript;
    TileScript tile;
    GridScript grid;

    //variables for tracking current tile position
    public int currTilePosX;
    public int currTilePosY;

    //variables for player's stored words
    public HashSet<string> foundWords = new HashSet<string>();

    // Start is called before the first frame update
    void Start()
    {
        //find Game Manager
        GameObject managerObject = GameObject.Find("Game Manager");
        if (managerObject != null)
        {
            managerScript = managerObject.GetComponent<ManagerScript>();
        }
        else
        {
            Debug.LogError("Manager not found!");
        }


        GameObject gridObject = GameObject.Find("Grid");
        if (gridObject != null)
        {
            grid = gridObject.GetComponent<GridScript>();
        }
        else
        {
            Debug.LogError("Grid not found!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        //if mouse was first clicked, used for validating starting a new wrd
        if (Input.GetMouseButtonDown(0) && checkMouseTileCollision())
        {
            buildingWord = true;
            addTileToWord(tile);
        }
        //if mouse is being held
        else if (Input.GetMouseButton(0))
        {
            //if mouse is touching a tile
            if (checkMouseTileCollision())
            {
                //Check if Tile is adjacent and not selected
                if (!tile.isSelected &&
                    (Math.Abs(tile.posX - currTilePosX) <= 1)  &&
                     (Math.Abs(tile.posY - currTilePosY) <= 1))
                {
                    //if valid, add tile to the word
                    addTileToWord(tile);
                }   
            }
        }
        else //if mouse is released, reset
        {
            //if word is valid, add it to our list
            //TODO: ON RELEASE WE CAN CHECK THE WORD IF ITS VALID AND ADD SCORE
            if (currentWord != string.Empty)
            {
                if (validWord(currentWord))
                    Debug.Log($"Added {currentWord}");
                    foundWords.Add(currentWord);
            }
            
            //reset wordbuilding
            buildingWord = false;
            currentWord = string.Empty;
            grid.UnselectAllTiles();
        }
    }

    //validates word found by the player
    public bool validWord(string word)
    {
        if (grid.boardWords.Contains(word) && !foundWords.Contains(word)) //in the possible words of the board, but not found words
        {
            //print($"Valid word {word}");
            return true;
        }
        else
        {
            return false;
        }

    }

    bool checkMouseTileCollision()
    {
        // Get the mouse position in world coordinates
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Check if the mouse position overlaps any 2D collider
        Collider2D collider = Physics2D.OverlapPoint(mousePosition);

        // If a collider is found and the object has the TileScript component
        if (collider != null)
        {
            tile = collider.gameObject.GetComponent<TileScript>();

            // Check if the TileScript component is attached to the GameObject
            if (tile != null)
            {
                //Debug.Log("Mouse is touching the " + tile.letter + " Tile");
                return true;
            }
        }
        //Debug.Log("Mouse is not touching a Tile");
        return false;
    }

    //adds tile moused over to the word
    void addTileToWord(TileScript tile)
    {
        //add letter to word, and set the tile to found while updating the currentTile positions
        currentWord += tile.letter;
        tile.Select();
        currTilePosX = tile.posX;
        currTilePosY = tile.posY;
    }
}
