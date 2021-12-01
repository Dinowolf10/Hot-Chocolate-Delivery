using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    private GameObject timeLimit;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            // Stores reference to TimeLimit game object
            timeLimit = GameObject.Find("TimeLimit");
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Ends level and displays pause menu to allow user to restart
    /// </summary>
    public void TimeUp()
    {
        timeLimit.GetComponentInChildren<UnityEngine.UI.Text>().text = "Ran out of time!";
    }
}
