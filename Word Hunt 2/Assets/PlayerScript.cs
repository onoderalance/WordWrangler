using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public string currentWord;
    public bool buildingWord;
    ManagerScript managerScript;
    TileScript tile;

    // Start is called before the first frame update
    void Start()
    {
        GameObject managerObject = GameObject.Find("Game Manager");
        if (managerObject != null)
        {
            managerScript = managerObject.GetComponent<ManagerScript>();
        }

        if (managerScript == null)
        {
            Debug.LogError("ManagerScript not found on Game Manager!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkMouseCollision();
        //if mouse is being held
        if (Input.GetMouseButton(0))
        {
            checkMouseCollision();
        }
        else
        {
            buildingWord = false;
            currentWord = string.Empty;
        }
        validWord(currentWord);
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

        // If a collider is found and the object is named "Tile"
        if (collider != null && collider.gameObject.name == "Tile")
        {
            Debug.Log("Mouse is touching the Tile");
            tile = collider.gameObject.GetComponent<TileScript>(); ;
            Debug.Log("Tile Letter: " + tile.letter);
            // Example: Change color of the Tile object when mouse is over it
            return true;
        }
        else
        {
            Debug.Log("Mouse is not touching the Tile");
            return false;
        }
        /* // Create a ray from the camera through the mouse position
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         RaycastHit hit;

         // Perform the raycast
         if (Physics.Raycast(ray, out hit))
         {
             // Check if the ray hit a GameObject with the Tile script
             tile = hit.collider.GetComponent<TileScript>();
             if (tile != null)
             {
                 // We have found a tile, now we can access its properties
                 Debug.Log($"Mouse is hovering over a Tile");

                 // You can perform additional actions here, like changing the color or triggering events
                 return true;
             }
         }
         Debug.Log($"Mouse is NOT hovering over a Tile");
         return false;*/
    }
}
