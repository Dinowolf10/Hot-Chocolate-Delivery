using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // References to main menu UI game objects, references grabbed in editor
    [SerializeField]
    private GameObject playButton, controlsButton, backButton, controlsText;

    /// <summary>
    /// Starts the game by loading the Level 1 scene
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    /// <summary>
    /// Shows controls text and back button while hiding the play and controls buttons
    /// </summary>
    public void ShowControls()
    {
        // Hides playButton and controlsButton
        playButton.SetActive(false);
        controlsButton.SetActive(false);

        // Shows backButton and controlsText
        backButton.SetActive(true);
        controlsText.SetActive(true);
    }

    /// <summary>
    /// Hides controls text and back button while showing the play and controls buttons
    /// </summary>
    public void HideControls()
    {
        // Hides backButton and controlsText
        backButton.SetActive(false);
        controlsText.SetActive(false);

        // Shows playButton and controlsButton
        playButton.SetActive(true);
        controlsButton.SetActive(true);
    }
}
