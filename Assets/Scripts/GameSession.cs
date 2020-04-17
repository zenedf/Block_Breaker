using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// This handles display information for each game session
/// </summary>
public class GameSession : MonoBehaviour
{
    #region Configuration Parameters
    // This is a 'Range' because it gives us a sliding bar to test the game speed with in the inspector.
    // Speed (1 = normal speed, 0.5 = half speed, 0 = no speed)
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;

    // How many points you get per block destroyed
    [SerializeField] int pointsPerBlockDestroyed = 10;

    // Text object that displays the game score
    [SerializeField] TextMeshProUGUI txtScore;

    // Text object that displays the amount of blocks you have left to destroy per level
    [SerializeField] TextMeshProUGUI txtBlockCount;
    #endregion Configuration Parameters

    #region Cached Reference
    // Reference to the SceneLoader.cs class.
    // Does this reference a script or the Level object which contains the SceneLoader.cs script?
    SceneLoader sceneLoader;

    // Referece to the Level.cs class.
    // Does this reference the Level object or the Level.cs script?
    Level level; // TESTING
    #endregion Cached Reference

    #region State Variables
    // The current score the player has accrued throughout the entire game session
    [SerializeField] int currentScore = 0;

    // How many blocks are left per left
    [SerializeField] int blocksLeft = 0;

    // Pause Button Code
    // (the pause implementation does not work currently)
    //[SerializeField] private bool isPausable_GameSession;
    #endregion State Variables

    /// <summary>
    /// This runs before the Start() method.
    /// This handles the singleton logic.
    /// </summary>
    void Awake()
    {
        // Get a count of how many 'GameSession' objects there are in the current scene.
        // The 'GameSession' object is the only object that doesn't get destroyed per level.
        int _gameStatusCount = FindObjectsOfType<GameSession>().Length;

        // If there's already more than 1 'GameSession' object, destroy yourself
        if (_gameStatusCount > 1)
        {
            // Put this line of code right before 'Destroy' if we're using the Singleton pattern to avoid bugs.
            gameObject.SetActive(false);

            // Destroy the current object this code is attached to.
            Destroy(gameObject);
        }
        else // If there's just one 'GameSession', don't destroy when the level loads in the future.
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    /// <summary>
    /// Initializes the cached references, and updates the current game score.
    /// </summary>
    private void Start()
    {
        // Initializes a 'SceneLoader' object
        // It handles the loading of scenes
        sceneLoader = FindObjectOfType<SceneLoader>();

        // Initializes a 'Level' object
        // It handles the objects in the level
        level = FindObjectOfType<Level>();
        blocksLeft = level.GetNumberOfBreakableBlocks();

        // Updates the current game score on the screen.
        txtScore.text = currentScore.ToString();

        #region Pause button testing
        //isPausable_GameSession = sceneLoader.isPausable;

        // This is for testing the pause button
        //txtScore.text = Time.timeScale.ToString();
        #endregion Pause button testing
    }


    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        #region This checks each frame to see if the pause button was hit
        // This is for testing the pause button
        // txtScore.text = Time.timeScale.ToString();

        // If the player has pressed the escape key
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    // sceneLoader = FindObjectOfType<SceneLoader>();
        //    // isPausable_GameSession = sceneLoader.isPausable;

        //    // If the player is able to pause or resume
        //    // if (isPausable_GameSession == true)
        //    //if (sceneLoader.isPausable == true)
        //    //{
        //    //    // If the game is currently paused
        //    //    if (Time.timeScale == 0)
        //    //    {
        //    //        // Resume the game
        //    //        sceneLoader.ResumeTheGame();
        //    //    }
        //    //    else
        //    //    {
        //    //        // Pause the game
        //    //        sceneLoader.PauseTheGame(true);
        //    //    }
        //    //}
        //}
        #endregion This checks each frame to see if the pause button was hit

        // Puts the game speed back to normal.
        Time.timeScale = gameSpeed;

        #region More pause button code
        // If the game wasn't paused from another location, keep updating the time with gameSpeed
        //if (Time.timeScale != 0)
        //{
        //    //Debug.Log("GameSession.Update, Time.timeScale is " + Time.timeScale);
        //    Time.timeScale = gameSpeed;
        //    //Debug.Log("GameSession.Update, Time.timeScale = gameSpeed is " + Time.timeScale);
        //}
        #endregion More pause button code
    }


    /// <summary>
    /// Updates the score based on how many blocks are destroyed.
    /// Then, updates the score on the screen.
    /// </summary>
    public void AddToScore()
    {
        // Updates the score when a block is destroyed.
        currentScore += pointsPerBlockDestroyed;

        // Updates the score the player sees.
        txtScore.text = currentScore.ToString();
    }


    /// <summary>
    /// This updates the number of blocks left on the screen and displays the number on the screen.
    /// </summary>
    public void UpdateBlockData()
    {
        // Updates the number or blocks that are left in the level
        blocksLeft = level.GetNumberOfBreakableBlocks(); // TESTING

        // Updates the Displays the updated number of blocks
        txtBlockCount.text = blocksLeft.ToString(); // TESTING
    }


    #region Backup of the UpdateBlockData() method.
    // This is a 
    // THe reason for the backup is that I'm trying to change some code in this method.

    ///// <summary>
    ///// This updates the number of blocks left on the screen and displays the number on the screen.
    ///// </summary>
    //public void UpdateBlockData()
    //{
    //    blocksLeft = FindObjectOfType<Level>().GetNumberOfBreakableBlocks();

    //    txtBlockCount.text = blocksLeft.ToString();
    //}
    #endregion Backup of the UpdateBlockData() method.


    /// <summary>
    /// Destroys the 'GameSession' object because it's the object that keeps the score information.
    /// </summary>
    public void ResetGameStats()
    {
        // Destroys the game object this code is attached to
        Destroy(gameObject);
    }
}