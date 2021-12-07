using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private GameObject timeLimit;

    private GameObject pauseMenu;

    public bool gamePaused = false;

    public bool timeUp = false;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            // Stores reference to TimeLimit game object
            timeLimit = GameObject.Find("TimeLimit");

            // Stores reference to PauseMenu game object
            pauseMenu = GameObject.Find("PauseMenu");
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }

        // Makes sure game is not paused
        ResumeGame();

        // Resets timeUp to false
        timeUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If player presses escape, pause or unpause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If the game is currently not paused, pause the game
            if (!gamePaused)
            {
                PauseGame();
                Debug.Log("Paused game");
            }
            // Otherwise the game is paused so resume the game
            else
            {
                ResumeGame();
                Debug.Log("Resume game");
            }
        }
    }

    /// <summary>
    /// Ends level and displays pause menu to allow user to restart
    /// </summary>
    public void TimeUp()
    {
        // Tells player they ran out of time
        timeLimit.GetComponentInChildren<UnityEngine.UI.Text>().text = "Ran out of time!";

        // Sets timeUp to true
        timeUp = true;
    }

    /// <summary>
    /// Pauses the game
    /// </summary>
    public void PauseGame()
    {
        // Sets time scale to 0
        Time.timeScale = 0;

        // Sets gamePaused to true
        gamePaused = true;

        // Shows pause menu
        pauseMenu.SetActive(true);

        // Unlocks the mouse
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// Resumes the game
    /// </summary>
    public void ResumeGame()
    {
        // Sets time scale to 1
        Time.timeScale = 1;

        // Sets gamePaused to false
        gamePaused = false;

        // Hides pause menu
        pauseMenu.SetActive(false);

        // Locks the mouse
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// Loads the next scene
    /// </summary>
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
