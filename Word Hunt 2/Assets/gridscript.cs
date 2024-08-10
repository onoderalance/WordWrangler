using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    public GameObject tile; 
    public int gridSize = 4; // 4x4 grid
    public int minimumValidWords = 25; 
    public HashSet<string> validWords; // from GameManager
    private List<string> boardWords; // valid words on current board
    private GameObject[,] grid;
    ManagerScript managerScript;

    void Start()
    {
        // get validWords
        GameObject managerObject = GameObject.Find("Game Manager");
        managerScript = managerObject.GetComponent<ManagerScript>();
        grid = new GameObject[gridSize, gridSize];

        // regen till valid
        GenerateValidGrid();
    }

    void GenerateValidGrid()
    {
        GenerateGrid();
        //bool isValid = false;

        //while (!isValid)
        //{
        //    GenerateGrid();

        //    boardWords = FindValidWordsOnBoard();

        //    if (boardWords.Count >= minimumValidWords)
        //    {
        //        isValid = true;
        //    }
        //    else
        //    {
        //        ClearGrid();
        //    }
        //}

        //Debug.Log($"Grid generated with {boardWords.Count} valid words");
    }


    void GenerateGrid()
    {
        float startX = -3f;
        float startY = 3f;
        float offset = 2f;  

        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                float posX = startX + x * offset;
                float posY = startY - y * offset;

                GameObject newTile = Instantiate(tile, new Vector2(posX, posY), Quaternion.identity, transform);

                grid[x, y] = newTile;
            }
        }

    }

    //List<string> FindValidWordsOnBoard()
    //{
    //    // implement later
    //}

    public GameObject GetTileAt(int x, int y)
    {
        if (x >= 0 && x < gridSize && y >= 0 && y < gridSize)
        {
            return grid[x, y];
        }
        else
        {
            return null;
        }
    }

    void ClearGrid()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        // clear grid array too
    }

    public bool validWord(string word)
    {
        if (managerScript != null && managerScript.isWordValid(word))
            return true;
        else
            return false;
    }
}
