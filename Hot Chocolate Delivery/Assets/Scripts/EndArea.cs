using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EndArea : MonoBehaviour
{
    private LevelManager levelManager;

    private void Start()
    {
        try
        {
            // Stores reference to levelManager script
            levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        }
        // Catches null reference of levelManager
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the player collides with the end area and the time has not run out, load the next level
        if (other.gameObject.tag == "Player" && !levelManager.timeUp)
        {
            levelManager.LoadNextLevel();
        }
    }
}
