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
    // This is an example for a global script.
    //public static GameSession gameSessionInstance;

    // Configuration Parameters

    // This is a 'Range' because it gives us a sliding bar to test the game speed with in the inspector.
    // Speed (1 = normal speed, 0.5 = half speed, 0 = no speed)
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;

    // How many points you get per block destroyed
    [SerializeField] int pointsPerBlockDestroyed = 10;

    // Text object that displays the game score
    [SerializeField] TextMeshProUGUI txtScore;

    // Text object that displays the amount of blocks you have left to destroy per level
    [SerializeField] TextMeshProUGUI txtBlockCount;

    // Cached Reference

    // Reference to the SceneLoader.cs class.
    // Does this reference a script or the Level object which contains the SceneLoader.cs script?
    SceneLoader sceneLoader;

    // Referece to the Level.cs class.
    // Does this reference the Level object or the Level.cs script?
    //Level level;

    // State Variables
    // The current score the player has accrued throughout the entire game session
    [SerializeField] int currentScore = 0;

    // How many blocks are left per left
    [SerializeField] int blocksLeft = 0;

    /// <summary>
    /// This runs before the Start() method.
    /// This handles the singleton logic.
    /// </summary>
    void Awake()
    {
        // This is an example for a global script.
        //gameSessionInstance = this;

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
        //level = FindObjectOfType<Level>();

        UpdateBlockData();

        // Updates the current game score on the screen.
        txtScore.text = currentScore.ToString();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Puts the game speed back to normal.
        Time.timeScale = gameSpeed;
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
    public void UpdateBlockData(Level level)
    {
        // Updates the number or blocks that are left in the level.
        blocksLeft = level.GetNumberOfBreakableBlocks();

        // Updates the Displays the updated number of blocks.
        txtBlockCount.text = blocksLeft.ToString();
    }

    #region UpdateBlockData() BACKUP


    /// <summary>
    /// This updates the number of blocks left on the screen and displays the number on the screen.
    /// </summary>
    public void UpdateBlockData()
    {
        // Updates the number or blocks that are left in the level.
        blocksLeft = FindObjectOfType<Level>().GetNumberOfBreakableBlocks();

        // Updates the Displays the updated number of blocks.
        txtBlockCount.text = blocksLeft.ToString();
    }


    #endregion

    /// <summary>
    /// Destroys the 'GameSession' object because it's the object that keeps the score information.
    /// </summary>
    public void ResetGameStats()
    {
        // Destroys the game object this code is attached to
        Destroy(gameObject);
    }

}