///TODO
///[ ] Set up a way to save the previous save data in a variable to display or update later. (Ex. your highest score)

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
    // Cached Reference

    //private Button btnNextLevel;
    //private Paddle paddle;
    //private Ball ball;
    //private GameSession gameSession;

    //[SerializeField] private GameObject objBtnNextLevel;
    [SerializeField] private GameObject objPaddle;
    [SerializeField] private GameObject objBall;
    [SerializeField] private GameObject objGameSession;

    [SerializeField] private int intCurrentSceneIndex;
    [SerializeField] private int intTotalNumberOfScenes;

    private readonly string strBtnNextLevel = "GameSession/GameCanvas/btnNextLevel";
    private readonly string strBtnQuitGame = "GameSession/GameCanvas/btnQuitGame";
    private readonly string strPaddle = "Paddle";
    private readonly string strBall = "Ball";
    private readonly string strGameOver = "GameOver";
    private readonly string strGameSession = "GameSession";

    /// <summary>
    /// Initialize the cached member variables.
    /// </summary>
    private void Start()
    {
        // Initializing these variables on at the Start method might be a problem.
        // If it is an issue, just initialize them where they're called in the code.

        //paddle = GameObject.Find(strPaddle).GetComponent<Paddle>();
        //ball = GameObject.Find(strBall).GetComponent<Ball>();
        //btnNextLevel = GameObject.Find(strBtnNextLevel).GetComponent<Button>();
        //gameSession = GameObject.Find(strGameSession).GetComponent<GameSession>();

        objPaddle = GameObject.Find(strPaddle);
        objBall = GameObject.Find(strBall);
        //objBtnNextLevel = GameObject.Find(strBtnNextLevel);
        objGameSession = GameObject.Find(strGameSession);

        //intCurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //intTotalNumberOfScenes = SceneManager.sceneCountInBuildSettings;
    }


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
    /// This is for when the player beats a level and the 'Next Level' button is available.
    /// The player controls are deactivated, the game is paused, the 'NextLevel' button is visible, and you can see your cursor so you can click the next button.
    /// </summary>
    public void NextLevelAndQuitButtons()
    {
        // Disable the player controlled paddle
        // GameObject.Find(strPaddle).GetComponent<Paddle>().gameObject.SetActive(false);
        //objPaddle.GetComponent<Paddle>().gameObject.SetActive(false);
        //objPaddle.gameObject.SetActive(false);
        objPaddle.SetActive(false);

        // Disable the ball
        // GameObject.Find(strBall).GetComponent<Ball>().gameObject.SetActive(false);
        //objBall.GetComponent<Ball>().gameObject.SetActive(false);
        //objBall.gameObject.SetActive(false);
        objBall.SetActive(false);

        // Enables the NextLevel button
        // GameObject.Find(strBtnNextLevel).GetComponent<Button>().gameObject.SetActive(true);
        // objBtnNextLevel.GetComponent<Button>().gameObject.SetActive(true);
        //objBtnNextLevel.gameObject.SetActive(true);
        //objBtnNextLevel.SetActive(true);
        GameObject.Find(strBtnNextLevel).SetActive(true);
        GameObject.Find(strBtnQuitGame).SetActive(true);

        // Makes the cursor visible
        Cursor.visible = true;

        // Pause the game
        Time.timeScale = 0;
    }


    /// <summary>
    /// This loads the next scene based on it's index.
    /// </summary>
    public void LoadNextScene() // Tutorial Code
    {
        #region My Code

        //ReadyForNextScene = true;

        #endregion My Code

        // If the next level button can be active, make it inactive.
        // This is to prevent it being active before the next scene,
        //   and if it isn't in the scene, it won't throw a null reference exception.
        if (GameObject.Find(strBtnNextLevel) == true)
        {
            GameObject.Find(strBtnNextLevel).GetComponent<Button>().gameObject.SetActive(false);
            GameObject.Find(strBtnQuitGame).GetComponent<Button>().gameObject.SetActive(false);
        }


        #region None of this worked
        // GameObject.Find("name") only returns active GameObjects. If no GameObject with "name" can be found, null is returned.

        // Make the button inactive
        // GameObject.Find(strBtnNextLevel).GetComponent<Button>().gameObject.SetActive(false);
        //objBtnNextLevel.GetComponent<Button>().gameObject.SetActive(false);
        //objBtnNextLevel.gameObject.SetActive(true);
        //objBtnNextLevel.SetActive(true);

        //if (objBtnNextLevel != false)
        //{
        //    objBtnNextLevel.GetComponent<Button>().gameObject.SetActive(false);
        //}
        //else if (objBtnNextLevel != null)
        //{
        //    Debug.Log(objBtnNextLevel);
        //}
        //else
        //{
        //    Debug.Log(objBtnNextLevel);
        //}

        // This code checks to see if the 'btnNextLevel' is in the scene hierarchy
        // If it is, then make it inactive.
        //if (btnNextLevel == true)
        //{
        //    //Button btn = GameObject.Find("GameSession/GameCanvas/btnNextLevel").GetComponent<Button>();
        //    //btn.gameObject.SetActive(false);
        //    btnNextLevel.gameObject.SetActive(false);
        //} 
        #endregion

        // Creates an index of the current active scenes in the 'Edit -> BuildSettings' in Unity
        intCurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // if the next scene isn't going to be the GameOver scene
        if (intCurrentSceneIndex + 1 != SceneManager.sceneCountInBuildSettings - 1)
        {
            Cursor.visible = false;
        }

        // Loads the next scene in the list.
        SceneManager.LoadScene(intCurrentSceneIndex + 1);
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


    #region My Code

    /// <summary>
    /// This loads the scene titled 'GameOver', regardles off what index it is at in 'Edit -> BuildSettings'
    /// </summary>
    public void LoadGameOverScene()
    {
        //ReadyForNextScene = true;

        // Makes the cursor visible
        Cursor.visible = true;

        // Loads the 'GameOver' scene.
        SceneManager.LoadScene(strGameOver);
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
