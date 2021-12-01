using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// Restarts current level
    /// </summary>
    public void RestartLevel()
    {
        // Reloads current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Returns the player to the main menu
    /// </summary>
    public void ReturnToMainMenu()
    {
        // Loads the main menu scene
        SceneManager.LoadScene("MainMenu");
    }
}
