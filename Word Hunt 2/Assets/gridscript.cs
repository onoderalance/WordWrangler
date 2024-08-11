using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    public GameObject tile; 
    public int gridSize = 4; // 4x4 grid
    public int minimumValidWords = 25; 
    public HashSet<string> boardWords; // valid words on current board
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

                // update var in tile
                TileScript tileScript = newTile.GetComponent<TileScript>();
                tileScript.SetPosition(x, y);

                grid[x, y] = newTile;
            }
        }

    }

    HashSet<string> FindValidWordsOnBoard()
    {
        HashSet<string> foundWords = new HashSet<string>();

        // Iterate over each tile on the grid
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                bool[,] visited = new bool[gridSize, gridSize];
                DFS(x, y, "", visited, foundWords);
            }
        }

        return foundWords;
    }

    void DFS(int x, int y, string currentWord, bool[,] visited, HashSet<string> foundWords)
    {
        if (x < 0 || x >= gridSize || y < 0 || y >= gridSize || visited[x, y])
            return;

        visited[x, y] = true;

        // append curr letter
        TileScript tileScript = grid[x, y].GetComponent<TileScript>();
        string newWord = currentWord + tileScript.GetLetter();

        if (validWord(newWord))
        {
            foundWords.Add(newWord);
        }

        DFS(x - 1, y, newWord, visited, foundWords); // l
        DFS(x + 1, y, newWord, visited, foundWords); // r
        DFS(x, y - 1, newWord, visited, foundWords); // d
        DFS(x, y + 1, newWord, visited, foundWords); // u
        DFS(x - 1, y - 1, newWord, visited, foundWords); // dl
        DFS(x + 1, y - 1, newWord, visited, foundWords); // dr
        DFS(x - 1, y + 1, newWord, visited, foundWords); // ul
        DFS(x + 1, y + 1, newWord, visited, foundWords); // ur

        // backtrack
        visited[x, y] = false;
    }

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

    public void UnselectAllTiles()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                TileScript tileScript = grid[x, y].GetComponent<TileScript>();
                tileScript.UnSelect();
            }
        }
    }
}
