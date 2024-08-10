using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public string currentWord;
    ManagerScript managerScript;

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
        validWord(currentWord);
    }

    public bool validWord(string word)
    {
        if (managerScript != null && managerScript.isWordValid(word))
            return true;
        else
            return false;
    }
}
