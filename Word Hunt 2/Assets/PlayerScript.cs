using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public string currentWord;
    public bool buildingWord;
    ManagerScript managerScript;
    TileScript tile;
    GridScript grid;

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
        if (Input.GetMouseButtonDown(0) && checkMouseCollision())
        {
            buildingWord = true;
            addTileToWord(tile);
        }
        //if mouse is being held
        else if (Input.GetMouseButton(0))
        {
            //if mouse is touching a tile
            if (checkMouseCollision())
            {
                //tile add validation
                if (!tile.isSelected)
                    addTileToWord(tile);
            }
        }
        else //if mouse is released, reset
        {
            //TODO: ON RELEASE WE CAN CHECK THE WORD IF ITS VALID AND ADD SCORE
            buildingWord = false;
            currentWord = string.Empty;
            grid.UnselectAllTiles();
        }
        //unfinished, but will check if the word is valid or not here
        //validWord(currentWord);
    }

    public bool validWord(string word)
    {
        if (managerScript != null && managerScript.isWordValid(word))
            return true;
        else
            return false;
    }

    bool checkMouseCollision()
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
                Debug.Log("Mouse is touching the " + tile.letter + " Tile");
                return true;
            }
        }
        Debug.Log("Mouse is not touching a Tile");
        return false;
    }

    //adds tile moused over to the word
    void addTileToWord(TileScript tile)
    {
        currentWord += tile.letter;
        tile.Select();
    }
}
