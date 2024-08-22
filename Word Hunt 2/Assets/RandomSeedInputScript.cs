using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RandomSeedInputScript : MonoBehaviour
{
    public int seed;
    public TMP_InputField inputField;
    public GameData gameData;
    private SaveSystem saveSystem;

    // Start is called before the first frame update
    void Start()
    {
        // Register the OnInputFieldChanged method to the onValueChanged event
        inputField.onValueChanged.AddListener(OnInputFieldChanged);

        //generates and sets a random seed
        SetSeed(GenerateSeed());
        print($"New Seed: {seed}");
        inputField.text = seed.ToString();
    }

    // This method is called whenever the input field's text is changed
    void OnInputFieldChanged(string newText)
    {
        int newSeed;

        string updatedSeed = newText;
        Debug.Log("Updated Text: " + updatedSeed);
        if (int.TryParse(updatedSeed, out newSeed))
        {
            SetSeed(newSeed);
            Debug.Log("Set new seed: " + newSeed);
        }
        else
        {
            Debug.Log("New input is not a valid seed (int).");
        }
    }

    // clean up the listener when the script is disabled or destroyed
    void OnDestroy()
    {
        inputField.onValueChanged.RemoveListener(OnInputFieldChanged);
    }

    int GenerateSeed()
    {
        // Generate a seed based on the current time
        return System.DateTime.Now.GetHashCode();
    }

    public void SetSeed(int newSeed)
    {
        seed = newSeed;
        gameData.seedNumber = newSeed;
        SaveSeed(newSeed);
        Random.InitState(newSeed);
    }

    public int GetCurrentSeed()
    {
        return seed;
    }

    //save current seed to savedata
    public void SaveSeed(int newSeed)
    {
        saveSystem = new SaveSystem();

        saveSystem.UpdateSeed(newSeed);
        
    }
}
