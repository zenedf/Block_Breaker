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
    #region My Code

    //[SerializeField] private GameObject pauseCanvas;

    // This is the Paddle
    //[SerializeField] private GameObject paddleControls;

    // This is the Ball
    //[SerializeField] private GameObject ballControls;

    //[SerializeField] private GameObject gameCanvas;

    //Ball ball;

    //UpdateInformation updateInfo = new UpdateInformation();

    //public bool ReadyForNextScene { get; private set; }

    //public bool IsPaused { get; private set; }

    //public bool nextLevelButton { get; private set; }

    ///// <summary>
    ///// This runs on start
    ///// </summary>
    //private void Start()
    //{
    //    //ball = playerControls2.GetComponent<Ball>(); // TESTING
    //    ball = GetComponent<Ball>(); // TESTING

    //    //updateInfo = GetComponent<UpdateInformation>(); // TESTING

    //    // I think the Start method runs after we load a scene,
    //    //  so this should work.
    //    ReadyForNextScene = false;

    //    PrepareForNextScene();
    //}

    ///// <summary>
    ///// This runs every frame
    ///// </summary>
    //private void Update()
    //{
    //    // If we're about to load another scene, prepare.
    //    if (ReadyForNextScene == true)
    //    {
    //        PrepareForNextScene();
    //    }

    //    if (nextLevelButton == false)
    //    {
    //        // If the player hits the pause key
    //        if (Input.GetKeyDown(KeyCode.Escape) == true)
    //        {
    //            // Check to see if you need to pause or resume the game.
    //            PauseOrResumeGame();
    //        }
    //    }
    //}

    #region Pause/Resume (My Code)

    ///// <summary>
    ///// Pause or resume the game, depending on the current state
    ///// </summary>
    //public void PauseOrResumeGame()
    //{
    //    // If the game is paused
    //    if (TheGameIsPaused() == true)
    //    {
    //        ResumeTheGame();
    //    }
    //    else // If the game is running
    //    if (TheGameIsPaused() == false)
    //    {
    //        PauseTheGame();
    //    }
    //}

    ///// <summary>
    ///// Is the game paused or running?
    ///// </summary>
    ///// <returns>Paused = True, Running = False</returns>
    //public bool TheGameIsPaused()
    //{
    //    if (Time.timeScale == 0) // The game is paused
    //    {
    //        IsPaused = true;
    //        return true;
    //    }
    //    else
    //    {
    //        IsPaused = false;
    //        return false;
    //    }
    //}

    ///// <summary>
    ///// Pause the game
    ///// </summary>
    //public void PauseTheGame()
    //{
    //    // If there is in deed a pauseCanvas
    //    if (pauseCanvas != null)
    //    {
    //        // Turn on the pause menu
    //        pauseCanvas.SetActive(true);

    //        // Turn off the game UI
    //        gameCanvas.SetActive(false);
    //    }

    //    // If both the Paddle and Ball objects exist
    //    if (playerControls1 != null && playerControls2 != null)
    //    {
    //        // Turn off the Paddle controls
    //        playerControls1.SetActive(false);

    //        // If the game hasn't been started by the player (If the ball is still stuck to the Paddle)
    //        if (playerControls2.GetComponent<Ball>().hasShot == false)
    //        {
    //            // Turn off the Ball controls
    //            playerControls2.SetActive(false);
    //        }
    //    }

    //    IsPaused = true;
    //    // Pause the game
    //    Time.timeScale = 0;
    //}

    /// <summary>
    /// This is for when the player beats a level and the 'Next Level' button is available
    /// </summary>
    public void NextLevelButton()
    {
        Paddle _paddle = GameObject.Find("Paddle").GetComponent<Paddle>();
        _paddle.gameObject.SetActive(false);


        Ball _ball = GameObject.Find("Ball").GetComponent<Ball>();
        _ball.gameObject.SetActive(false);


        Button btn = GameObject.Find("GameSession/GameCanvas/btnNextLevel").GetComponent<Button>();
        btn.gameObject.SetActive(true);


        // Pause the game
        Time.timeScale = 0;
    }

    ///// <summary>
    ///// Resume the game
    ///// </summary>
    //public void ResumeTheGame()
    //{
    //    // If the Pause Canvas exists
    //    if (pauseCanvas != null)
    //    {
    //        // Turn off the pause menu
    //        pauseCanvas.SetActive(false);
    //        // Turn on the game gui
    //        gameCanvas.SetActive(true);
    //    }

    //    // If these two exist
    //    if (playerControls1 != null && playerControls2 != null)
    //    {
    //        // Turn on the Paddle controls
    //        playerControls1.SetActive(true);
    //        // Turn on the Ball controls
    //        playerControls2.SetActive(true);
    //    }

    //    // If the NextLevel button is on the screen
    //    if (nextLevelButton == true)
    //    {
    //        // Take the NextLevel button off the screen
    //        nextLevelButton = false;
    //    }

    //    // Set IsPaused flag to false
    //    IsPaused = false;

    //    // Resume the game
    //    Time.timeScale = 1;
    //}

    ///// <summary>
    ///// Make sure the game isn't paused and the pauseCanvas is off
    ///// </summary>
    //public void PrepareForNextScene()
    //{
    //    ResumeTheGame();
    //}

    #endregion Pause/Resume (My Code)


    #endregion My Code



    #region SceneLoader (Tutorial Code)

    /// <summary>
    /// This loads the next scene based on it's index.
    /// </summary>
    public void LoadNextScene() // Tutorial Code
    {
        #region My Code

        //ReadyForNextScene = true;

        #endregion My Code


        // This is so the Button won't stay on the screen when you start the next scene.
        if (GameObject.Find("GameSession/GameCanvas/btnNextLevel") == true)
        {
            Button btn = GameObject.Find("GameSession/GameCanvas/btnNextLevel").GetComponent<Button>();
            btn.gameObject.SetActive(false);
        }


        // Creates an index of the current active scenes in the 'Edit -> BuildSettings' in Unity
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;


        // Loads the next scene in the list.
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    /// <summary>
    /// Turn the controls back on and turn off the button. Also, unpause the game
    /// </summary>
    //public void ResetThingsBeforeLoadingScene()
    //{
    //    Paddle _paddle = GameObject.Find("Paddle").GetComponent<Paddle>();
    //    _paddle.gameObject.SetActive(true);


    //    Ball _ball = GameObject.Find("Ball").GetComponent<Ball>();
    //    _ball.gameObject.SetActive(true);



    //    Button btn = GameObject.Find("GameSession/GameCanvas/btnNextLevel").GetComponent<Button>();
    //    btn.gameObject.SetActive(false);

    //    // Resume the game
    //    Time.timeScale = 1;
    //}


    /// <summary>
    /// This loads the first scene in the 'Edit -> BuildSettings'
    /// </summary>
    public void LoadStartScene() // Tutorial Code
    {
        #region My Code

        //ReadyForNextScene = true;

        #endregion My Code

        // Loads the first/intro/start scene.
        SceneManager.LoadScene(0);


        // This resets all the game stats of our game session such as our game score
        if (GameObject.Find("GameSession") == true)
        {
            GameObject.Find("GameSession").GetComponent<GameSession>().ResetGameStats();
        }
    }

    #region My Code

    /// <summary>
    /// This loads the scene titled 'GameOver', regardles off what index it is at in 'Edit -> BuildSettings'
    /// </summary>
    public void LoadGameOverScene()
    {

        //ReadyForNextScene = true;

        // Loads the 'GameOver' scene.
        SceneManager.LoadScene("GameOver");
    }

    #endregion My Code

    /// <summary>
    /// This closes the application
    /// </summary>
    public void QuitGame() // Tutorial Code
    {
        // Closes the current application you are running.
        Application.Quit();
    }

    #endregion SceneLoader (Tutorial Code)
}
