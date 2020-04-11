using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This handles the scene controls.
/// </summary>
public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;

    [SerializeField] private GameObject playerControls;

    [SerializeField] private GameObject gameCanvas;

    public bool ReadyForNextScene { get; private set; }

    public bool IsPaused { get; private set; }

    /// <summary>
    /// This runs on start
    /// </summary>
    private void Start()
    {
        // I think the Start method runs after we load a scene,
        //  so this should work.
        ReadyForNextScene = false;

        PrepareForNextScene();
    }

    /// <summary>
    /// This runs every frame
    /// </summary>
    private void Update()
    {
        // If we're about to load another scene, prepare.
        if (ReadyForNextScene == true)
        {
            PrepareForNextScene();
        }

        // If the player hit the pause key
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            // Check to see if you need to pause or resume the game.
            PauseOrResumeGame();
        }
    }

    #region Pause/Resume

    /// <summary>
    /// Pause or resume the game, depending on the current state
    /// </summary>
    public void PauseOrResumeGame()
    {
        // If the game is paused
        if (TheGameIsPaused() == true)
        {
            ResumeTheGame();
        }
        else // If the game is running
        if (TheGameIsPaused() == false)
        {
            PauseTheGame();
        }
    }

    /// <summary>
    /// Is the game paused or running?
    /// </summary>
    /// <returns>Paused = True, Running = False</returns>
    public bool TheGameIsPaused()
    {
        if (Time.timeScale == 0) // The game is paused
        {
            IsPaused = true;
            return true;
        }
        else
        {
            IsPaused = false;
            return false;
        }
    }

    /// <summary>
    /// Pause the game
    /// </summary>
    public void PauseTheGame()
    {
        if (pauseCanvas != null)
        {
            // Turn on the pause menu
            pauseCanvas.SetActive(true);
            gameCanvas.SetActive(false);
        }

        if (playerControls != null)
        {
            // Turn off the player controls
            playerControls.SetActive(false);
        }

        IsPaused = true;
        Time.timeScale = 0;
    }

    /// <summary>
    /// Resume the game
    /// </summary>
    public void ResumeTheGame()
    {
        if (pauseCanvas != null)
        {
            // Turn off the pause menu
            pauseCanvas.SetActive(false);
            gameCanvas.SetActive(true);
        }

        if (playerControls != null)
        {
            // Turn on the player controls
            playerControls.SetActive(true);
        }

        IsPaused = false;
        Time.timeScale = 1;
    }

    /// <summary>
    /// Make sure the game isn't paused and the pauseCanvas is off
    /// </summary>
    public void PrepareForNextScene()
    {
        ResumeTheGame();
    }

    #endregion

    #region SceneLoader

    /// <summary>
    /// This loads the next scene based on it's index.
    /// </summary>
    public void LoadNextScene()
    {
        ReadyForNextScene = true;

        // Creates an index of the current active scenes in the 'Edit -> BuildSettings' in Unity
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Loads the next scene in the list.
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    /// <summary>
    /// This loads the first scene in the 'Edit -> BuildSettings'
    /// </summary>
    public void LoadStartScene()
    {
        ReadyForNextScene = true;

        // Loads the first/intro/start scene.
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// This loads the scene titled 'GameOver', regardles off what index it is at in 'Edit -> BuildSettings'
    /// </summary>
    public void LoadGameOverScene()
    {
        ReadyForNextScene = true;

        // Loads the 'GameOver' scene.
        SceneManager.LoadScene("GameOver");
    }

    /// <summary>
    /// This closes the application
    /// </summary>

    //public void QuitGame()
    //{
    //    // Closes the current application you are running.
    //    Application.Quit();
    //}

    #endregion

    public void Quit()
    {
        // Closes the current application you are running.
        Application.Quit();
    }

}
