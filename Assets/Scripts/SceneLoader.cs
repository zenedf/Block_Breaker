///TODO
///[ ] Take the pause and resume functions to make a whole new script you could re-use for any game.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This handles the scene controls.
/// </summary>
public class SceneLoader : MonoBehaviour
{
    //private Button btnNextLevel;
    //private Paddle paddle;
    //private Ball ball;
    //private GameSession gameSession;

    // Cached References

    private GameObject objPaddle;
    private GameObject objBall;
    private GameObject objGameSession;
    private GameObject objPauseCanvas;
    // private GameObject objBtnNextLevel; // Test this to see if it will work.
    // private GameObject objBtnQuitGame; // Test this to see if it will work.

    // State Variables

    private int intCurrentSceneIndex;
    private int intTotalNumberOfScenes;
    
    // Location of an object as a string.
    private readonly string strBtnNextLevel = "GameSession/GameCanvas/btnNextLevel";
    private readonly string strBtnQuitGame = "GameSession/GameCanvas/btnQuitGame";
    private readonly string strPauseCanvas = "GameSession/PauseCanvas";
    private readonly string strPaddle = "Paddle";
    private readonly string strBall = "Ball";
    private readonly string strGameOver = "GameOver";
    private readonly string strGameSession = "GameSession";
    private readonly string strTime = "GameSession/PauseCanvas/Panel/txtMPH";

    /// <summary>
    /// Initialize the cached member variables.
    /// </summary>
    private void Start()
    {
        objPaddle = GameObject.Find(strPaddle);
        objBall = GameObject.Find(strBall);
        objGameSession = GameObject.Find(strGameSession);
        objPauseCanvas = GameObject.Find(strPauseCanvas);
        // objBtnNextLevel = GameObject.Find(strBtnNextLevel); // Test this to see if it will work.
        // objBtnQuitGame = GameObject.Find(strBtnNextLevel); // Test this to see if it will work.

        // If the objPauseCanvas is in the current scene hierarchy and active in that hierarchy.
        if (objPauseCanvas == true)
        {
            // Set the PauseCanvas object in the scene hierarchy to inactive.
            GameObject.Find(strPauseCanvas).SetActive(false);

            // Set the PauseCanvas object in the scene hierarchy to inactive.
            // objPauseCanvas.SetActive(false);
            // I don't know if this will work, but I am going to try.

            // Make the cursor invisible.
            Cursor.visible = false;
        }
    }

    /// <summary>
    /// Pause the game whether or not the player pressed the pause button.
    /// </summary>
    public void PauseTheGame(bool _pauseButtonPressed)
    {
        // If the player didn't press the pause button.
        if (_pauseButtonPressed == true)
        {
            objPauseCanvas.SetActive(true);
        }

        // Makes the cursor visible.
        Cursor.visible = true;

        // Pause the game.
        Time.timeScale = 0;

        // If the Paddle object is in the current hierarchy.
        if (objPaddle != null)
        {
            // Set the Paddle object to inactive.
            objPaddle.SetActive(false);
        }

        // If the Ball object is in the current hierarchy.
        if (objBall != null)
        {
            // Set the Ball object to inactive.
            objBall.SetActive(false);
        }
    }

    /// <summary>
    /// Resume the game.
    /// </summary>
    public void ResumeTheGame()
    {
        // If the PauseCanvas object is in the current scene hierarchy.
        // if (objPauseCanvas != null) // try this instead of the code below because GameObject.Find(strPauseCanvas) was already initialized.
        if (GameObject.Find(strPauseCanvas) != null)
        {
            // Set the PauseCanvas object to inactive.
            objPauseCanvas.SetActive(false);
        }

        // Make the cursor visible.
        Cursor.visible = false;

        // Resume the game.
        Time.timeScale = 1;

        // If the Paddle object is in the current scene hierarchy.
        if (objPaddle != null)
        {
            // Set the Paddle object to active.
            objPaddle.SetActive(true);
        }

        // If the Ball object is in the current scene hierarchy.
        if (objBall != null)
        {
            // Set the Ball object to active.
            objBall.SetActive(true);
        }
    }

    /// <summary>
    /// This is for when the player beats a level and the 'Next Level' button is in the scene.
    /// The player controls are deactivated, the game is paused, the 'NextLevel' and the 'QuitGame' buttons are visible, and the cursor is visible so you can click the next or the quit button.
    /// </summary>
    public void NextLevelAndQuitButtons()
    {
        // Set the Next Level Button in the scene to active
        GameObject.Find(strBtnNextLevel).SetActive(true);
        // Try objBtnNextLevel.SetActive(true); only if the initialization of this object works.

        // Set the Quit Game Button in the scene to active
        GameObject.Find(strBtnQuitGame).SetActive(true);
        // Try objBtnQuitGame.SetActive(true); only if the initialization of this object works.

        // Pause the game even though the player didn't press the pause button
        PauseTheGame(false);
    }

    /// <summary>
    /// This loads the next scene based on it's index.
    /// </summary>
    public void LoadNextScene()
    {
        // Set the game speed to normal
        Time.timeScale = 1;

        // If the next level button can be active, make it inactive.
        // This is to prevent it being active before the next scene,
        // and if it isn't in the scene, it won't throw a null reference exception.
        if (GameObject.Find(strBtnNextLevel) == true)
        {
            // Set the Next Level Button to inactive.
            GameObject.Find(strBtnNextLevel).GetComponent<Button>().gameObject.SetActive(false);

            // Set the Quite Game Button to inactive.
            GameObject.Find(strBtnQuitGame).GetComponent<Button>().gameObject.SetActive(false);
        }

        // Creates an index of the current active scenes in the 'Edit -> BuildSettings' in Unity.
        intCurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // If the next scene after the current scene is the GameOver scene.
        if (intCurrentSceneIndex + 1 == SceneManager.sceneCountInBuildSettings - 1)
        {
            // Do nothing
        }
        else
        {
            // Make the cursor inactive.
            Cursor.visible = false;
        }

        // Loads the next scene in the list.
        SceneManager.LoadScene(intCurrentSceneIndex + 1);

        //objGameSession.GetComponent<GameSession>().UpdateBlockData(); // TESTING
    }

    /// <summary>
    /// This loads the first scene in the 'Edit -> BuildSettings'.
    /// </summary>
    public void LoadStartScene()
    {
        // Make the cursor visible
        Cursor.visible = true;

        // Load the first/intro/start scene.
        SceneManager.LoadScene(0);

        // If the user played this game before going back to the start menu, erase the previous data.
        // If a GameSession object is in the current scene hierarchy.
        if (objGameSession == true)
        {
            // This resets all the game stats of our game session. (Ex. our game score)
            objGameSession.GetComponent<GameSession>().ResetGameStats();
        }
    }

    /// <summary>
    /// This loads the scene titled 'GameOver', regardles off what index it is at in 'Edit -> BuildSettings'.
    /// </summary>
    public void LoadGameOverScene()
    {
        // Makes the cursor visible.
        Cursor.visible = true;

        // Loads the 'GameOver' scene.
        SceneManager.LoadScene(strGameOver);
    }

    /// <summary>
    /// This closes the application.
    /// </summary>
    public void QuitGame()
    {

        // Closes the current application you are running.
        Application.Quit();
    }
}