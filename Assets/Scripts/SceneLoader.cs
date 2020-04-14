///TODO
///[ ] Set up a way to save the previous save data in a variable to display or update later. (Ex. your highest score)

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
    // Cached Reference

    //private Button btnNextLevel;
    //private Paddle paddle;
    //private Ball ball;
    //private GameSession gameSession;

    #region Other Variables

    [SerializeField] int intTime;
    private GameObject objPaddle;
    private GameObject objBall;
    private GameObject objGameSession;
    private GameObject objPauseCanvas;
    
    private int intCurrentSceneIndex;
    private int intTotalNumberOfScenes;

    private readonly string strBtnNextLevel = "GameSession/GameCanvas/btnNextLevel";
    private readonly string strBtnQuitGame = "GameSession/GameCanvas/btnQuitGame";
    private readonly string strPauseCanvas = "GameSession/PauseCanvas";
    private readonly string strPaddle = "Paddle";
    private readonly string strBall = "Ball";
    private readonly string strGameOver = "GameOver";
    private readonly string strGameSession = "GameSession";
    private readonly string strTime = "GameSession/PauseCanvas/Panel/txtMPH";

    // This is for debugging the pause button
    //[SerializeField] public bool isPausable;
    //[SerializeField] public int counts_times_isPausable_value_changed = 0;

    #endregion

    /// <summary>
    /// Initialize the cached member variables.
    /// </summary>
    private void Start()
    {
        //Debug.Log("SceneLoader.Start()");


        // TESTING
        //isPausable = true; 

        objPaddle = GameObject.Find(strPaddle);
        objBall = GameObject.Find(strBall);
        objGameSession = GameObject.Find(strGameSession);
        objPauseCanvas = GameObject.Find(strPauseCanvas);
        if (objPauseCanvas == true)
        {
            GameObject.Find(strPauseCanvas).SetActive(false);
            Cursor.visible = false;
        }
    }

    /// <summary>
    /// Handles pausing the game whether or not the player pressed the pause button.
    /// </summary>
    public void PauseTheGame(bool _pauseButtonPressed)
    {
        //Debug.Log("SceneLoader.PauseTheGame()");

        // If the game needs to be paused, but it wasn't due to the player pressing the pause button
        if (_pauseButtonPressed == false)
        {
            //isPausable = false;

            // Makes the cursor visible
            Cursor.visible = true;

            // Pause the game
            Time.timeScale = 0;

            if (objPaddle != null)
            {
                objPaddle.SetActive(false);
            }
            if (objBall != null)
            {
                objBall.SetActive(false);
            }
        }
        else
        {
            //isPausable = true;
            //counts_times_isPausable_value_changed++;

            objPauseCanvas.SetActive(true);

            // Makes the cursor visible
            Cursor.visible = true;

            // Pause the game
            Time.timeScale = 0;

            if (objPaddle != null)
            {
                objPaddle.SetActive(false);
            }
            if (objBall != null)
            {
                objBall.SetActive(false);
            }
        }
    }

    /// <summary>
    /// TODO
    /// </summary>
    public void ResumeTheGame()
    {
        //Debug.Log("SceneLoader.ResumeTheGame()");


        // TESTING
        //isPausable = true;
        //Debug.Log("SceneLoader.ResumeTheGame(), isPausable just changed to TRUE");

        if (GameObject.Find(strPauseCanvas) != null)
        {
            objPauseCanvas.SetActive(false);
        }

        // Makes the cursor visible
        Cursor.visible = false;

        // Resume the game
        Time.timeScale = 1;

        if (objPaddle != null)
        {
            objPaddle.SetActive(true);
        }
        if (objBall != null)
        {
            objBall.SetActive(true);
        }
    }

    /// <summary>
    /// This is for when the player beats a level and the 'Next Level' button is available.
    /// The player controls are deactivated, the game is paused, the 'NextLevel' button is visible, and you can see your cursor so you can click the next button.
    /// </summary>
    public void NextLevelAndQuitButtons()
    {
        //Debug.Log("SceneLoader.NextLevelAndQuitButtons()");


        // TESTING
        //isPausable = false;
        //Debug.Log("SceneLoader.NextLevelAndQuitButtons = " + isPausable);

        GameObject.Find(strBtnNextLevel).SetActive(true);
        GameObject.Find(strBtnQuitGame).SetActive(true);

        PauseTheGame(false);

        // Pause the game
        //Time.timeScale = 0; // This Works
    }


    /// <summary>
    /// This loads the next scene based on it's index.
    /// </summary>
    public void LoadNextScene() // Tutorial Code
    {
        //Debug.Log("SceneLoader.LoadNextScene()");


        // TESTING
        //isPausable = true; 
        //Debug.Log("SceneLoader.LoadNextScene = " + isPausable);

        Time.timeScale = 1;

        // If the next level button can be active, make it inactive.
        // This is to prevent it being active before the next scene,
        //   and if it isn't in the scene, it won't throw a null reference exception.
        if (GameObject.Find(strBtnNextLevel) == true)
        {
            GameObject.Find(strBtnNextLevel).GetComponent<Button>().gameObject.SetActive(false);
            GameObject.Find(strBtnQuitGame).GetComponent<Button>().gameObject.SetActive(false);
        }

        // Creates an index of the current active scenes in the 'Edit -> BuildSettings' in Unity
        intCurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        // TESTING
        if (intCurrentSceneIndex + 1 == SceneManager.sceneCountInBuildSettings - 1)
        {
            //isPausable = false;
        }
        else
        {
            //isPausable = true;

            Cursor.visible = false;
        }

        // Loads the next scene in the list.
        SceneManager.LoadScene(intCurrentSceneIndex + 1);
    }

    /// <summary>
    /// This loads the first scene in the 'Edit -> BuildSettings'
    /// </summary>
    public void LoadStartScene() // Tutorial Code
    {
        //Debug.Log("SceneLoader.LoadStartScene()");


        // TESTING
        //isPausable = false; 
        //Debug.Log("SceneLoader.LoadStartScene = " + isPausable);

        // Makes the cursor visible
        Cursor.visible = true;

        // Loads the first/intro/start scene.
        SceneManager.LoadScene(0);


        // If the user played this game before going back to the start menu, erase the previous data.
        if (objGameSession == true) // GameObject.Find(gameSession);
        {
            // This resets all the game stats of our game session. (Ex. our game score)
            //GameObject.Find(strGameSession).GetComponent<GameSession>().ResetGameStats();
            objGameSession.GetComponent<GameSession>().ResetGameStats();
            //objGameSession.ResetGameStats();
        }
    }


    /// <summary>
    /// This loads the scene titled 'GameOver', regardles off what index it is at in 'Edit -> BuildSettings'
    /// </summary>
    public void LoadGameOverScene()
    {
        //Debug.Log("SceneLoader.LoadGameOverScene()");

        // TESTING
        //isPausable = false;
        //counts_times_isPausable_value_changed++;
        //Debug.Log("SceneLoader.LoadGameOverScene = " + isPausable);

        // Makes the cursor visible
        Cursor.visible = true;

        // Loads the 'GameOver' scene.
        SceneManager.LoadScene(strGameOver);
    }


    /// <summary>
    /// This closes the application
    /// </summary>
    public void QuitGame() // Tutorial Code
    {
        // Closes the current application you are running.
        Application.Quit();
    }
}
