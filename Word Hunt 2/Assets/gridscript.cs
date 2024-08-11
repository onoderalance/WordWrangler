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
    TileScript tileScript;

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
        bool isValid = false;
        int retries = 0;
        int maxRetries = 100;
        while (!isValid && retries < maxRetries)
        {
            Debug.Log("Attempt in while loop");
            GenerateGrid();
            boardWords = FindValidWordsOnBoard();

            if (boardWords.Count >= minimumValidWords)
            {
                isValid = true;
            }
            else
            {
                ClearGrid();
                retries++;
            }
        }
        Debug.Log($"Grid generated with {boardWords.Count} valid words");
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
        Debug.Log("Attempt in find valid words");
        HashSet<string> foundWords = new HashSet<string>();

        // iterate over each tile on the grid
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
        Debug.Log("Attempt in DFS");
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

        // stack to avoid deep recursion
        Stack<(int, int, string)> stack = new Stack<(int, int, string)>();
        stack.Push((x, y, newWord));

        while (stack.Count > 0)
        {
            var (curX, curY, word) = stack.Pop();
            
            int[,] directions = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 }, { -1, -1 }, { 1, -1 }, { -1, 1 }, { 1, 1 } };
            for (int i = 0; i < 8; i++)
            {
                int newX = curX + directions[i, 0];
                int newY = curY + directions[i, 1];

                if (newX >= 0 && newX < gridSize && newY >= 0 && newY < gridSize && !visited[newX, newY])
                {
                    newWord = word + grid[newX, newY].GetComponent<TileScript>().GetLetter();
                    if (validWord(newWord))
                    {
                        foundWords.Add(newWord);
                    }
                    visited[newX, newY] = true;
                    stack.Push((newX, newY, newWord));
                }
            }
        }

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
        // clear array
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                grid[x, y] = null;
            }
        }
    }

    public bool validWord(string word)
    {
        GameObject managerObject = GameObject.Find("Game Manager");
        managerScript = managerObject.GetComponent<ManagerScript>();
        if (managerScript.isWordValid(word))
        {
            return true;
        }
        else
        {
            return false;
        }
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
