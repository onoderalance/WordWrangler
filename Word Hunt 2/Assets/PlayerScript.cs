using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int test = 2;
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

        print(test.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (managerScript == null)
        {
            print("death");
        }
        else
        {
            print("okay");
        }
        if (managerScript != null && managerScript.isWordValid("rOD"))
            print("yup");
        else
            print("nop");
    }
}
