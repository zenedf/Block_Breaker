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
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;

    [SerializeField] int pointsPerBlockDestroyed = 10;

    // Text object that displays the game score
    [SerializeField] TextMeshProUGUI txtScore;

    // Text object that displays the amount of blocks you have left to destroy per level
    [SerializeField] TextMeshProUGUI txtBlockCount;

    #endregion

    #region Cached Reference

    SceneLoader sceneLoader;

    Level level; // TESTING

    #endregion


    #region State Variables

    [SerializeField] int currentScore = 0;
    [SerializeField] int blocksLeft = 0;

    // Pause Button Code
    //[SerializeField] private bool isPausable_GameSession;

    #endregion

    /// <summary>
    /// TODO
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
        level = FindObjectOfType<Level>(); // TESTING
        blocksLeft = level.GetNumberOfBreakableBlocks(); // TESTING

        // Updates the current game score on the screen.
        txtScore.text = currentScore.ToString();

        #region Pause button testing

        //isPausable_GameSession = sceneLoader.isPausable;

        // This is for testing the pause button
        //txtScore.text = Time.timeScale.ToString();

        #endregion
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

        #endregion

        // Puts the game speed back to normal.
        Time.timeScale = gameSpeed;

        #region More Pause Button code

        // If the game wasn't paused from another location, keep updating the time with gameSpeed
        //if (Time.timeScale != 0)
        //{
        //    //Debug.Log("GameSession.Update, Time.timeScale is " + Time.timeScale);
        //    Time.timeScale = gameSpeed;
        //    //Debug.Log("GameSession.Update, Time.timeScale = gameSpeed is " + Time.timeScale);
        //}

        #endregion
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
        //blocksLeft = FindObjectOfType<Level>().GetNumberOfBreakableBlocks();

        // TESTING
        //blocksLeft += level.GetNumberOfBreakableBlocks(); // TESTING
        // The first level had 2 blocks starting out. The number did say there were two.
        // However, as soon as you get one block, the amount went up by one.
        // The amount then stayed the same the rest of the game.

        blocksLeft = level.GetNumberOfBreakableBlocks(); // TESTING


        txtBlockCount.text = blocksLeft.ToString(); // TESTING
    }




    // This is a backup of the UpdateBlockData() method.

    ///// <summary>
    ///// This updates the number of blocks left on the screen and displays the number on the screen.
    ///// </summary>
    //public void UpdateBlockData()
    //{
    //    blocksLeft = FindObjectOfType<Level>().GetNumberOfBreakableBlocks();

    //    txtBlockCount.text = blocksLeft.ToString();
    //}


    /// <summary>
    /// Destroys the 'GameSession' object because it's the object that keeps the score information.
    /// </summary>
    public void ResetGameStats()
    {
        // Destroys the game object this code is attached to
        Destroy(gameObject);
    }

}
