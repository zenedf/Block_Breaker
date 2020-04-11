using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This handles the scene controls.
/// </summary>
public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;

    // This is the Paddle
    [SerializeField] private GameObject playerControls1;

    // This is the Ball
    [SerializeField] private GameObject playerControls2;

    [SerializeField] private GameObject gameCanvas;

    Ball ball;

    UpdateInformation updateInfo = new UpdateInformation();

    public bool ReadyForNextScene { get; private set; }

    public bool IsPaused { get; private set; }

    public bool nextLevelButton { get; private set; }

    /// <summary>
    /// This runs on start
    /// </summary>
    private void Start()
    {
        //ball = playerControls2.GetComponent<Ball>(); // TESTING
        ball = GetComponent<Ball>(); // TESTING

        //updateInfo = GetComponent<UpdateInformation>(); // TESTING

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

        if (nextLevelButton == false)
        {
            // If the player hits the pause key
            if (Input.GetKeyDown(KeyCode.Escape) == true)
            {
                // Check to see if you need to pause or resume the game.
                PauseOrResumeGame();
            }
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
        // If there is in deed a pauseCanvas
        if (pauseCanvas != null)
        {
            // Turn on the pause menu
            pauseCanvas.SetActive(true);

            // Turn off the game UI
            gameCanvas.SetActive(false);
        }

        // If both the Paddle and Ball objects exist
        if (playerControls1 != null && playerControls2 != null)
        {
            // Turn off the Paddle controls
            playerControls1.SetActive(false);

            // If the game hasn't been started by the player (If the ball is still stuck to the Paddle)
            if (playerControls2.GetComponent<Ball>().hasShot == false)
            {
                // Turn off the Ball controls
                playerControls2.SetActive(false);
            }
        }

        IsPaused = true;
        // Pause the game
        Time.timeScale = 0;
    }

    /// <summary>
    /// This is for when the player beats a level and the 'Next Level' button is available
    /// </summary>
    public void NextLevelButton()
    {
        // If both the Paddle and Ball objects exist
        if (playerControls1 != null && playerControls2 != null)
        {
            // Turn off the Paddle controls
            playerControls1.SetActive(false);

            // Turn off the Ball controls
            playerControls2.SetActive(false);
        }

        // These two lines pause everything in the game
        //playerControls.SetActive(false);
        // There are two different scripts I need to deactivate to make everything paused, so the above doesn't fully work


        // Pause the game
        Time.timeScale = 0;

        // When true, the NextLevel button is on the screen, and we have disabled the pause button
        nextLevelButton = true;
    }

    /// <summary>
    /// Resume the game
    /// </summary>
    public void ResumeTheGame()
    {
        // If the Pause Canvas exists
        if (pauseCanvas != null)
        {
            // Turn off the pause menu
            pauseCanvas.SetActive(false);
            // Turn on the game gui
            gameCanvas.SetActive(true);
        }

        // If these two exist
        if (playerControls1 != null && playerControls2 != null)
        {
            // Turn on the Paddle controls
            playerControls1.SetActive(true);
            // Turn on the Ball controls
            playerControls2.SetActive(true);
        }

        // If the NextLevel button is on the screen
        if (nextLevelButton == true)
        {
            // Take the NextLevel button off the screen
            nextLevelButton = false;
        }

        // Set IsPaused flag to false
        IsPaused = false;

        // Resume the game
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
}
