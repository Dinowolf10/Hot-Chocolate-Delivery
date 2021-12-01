using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeLimit : MonoBehaviour
{
    public float TimeLeft = 20.0f; // time left in seconds. Change this to change how much time each level gets

    [SerializeField]
    private GameObject levelManager;

    // Start is called before the first frame update
    void Start()
    {
        // Store reference to LevelManager game object
        try
        {
            levelManager = GameObject.Find("LevelManager");
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeLeft > 0) {
            TimeLeft -= Time.deltaTime;
            this.gameObject.GetComponent<UnityEngine.UI.Text>().text = "Time Remaining: " + (int)TimeLeft;
            if(TimeLeft <= 0.0f) {
                // Calls TimeUp method from levelManager
                levelManager.GetComponent<LevelManager>().TimeUp();
            }
        }
    }
}
