using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public static bool debugStart = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for left mouse button click
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collider = Physics2D.OverlapPoint(mousePosition);

            if (collider != null)
            {
                Debug.Log("Start clicked");
                //start game
                SceneManager.LoadScene("Main");
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Started debug mode");
            debugStart = true;
            //start game
            SceneManager.LoadScene("Main");
        }
    }
}
