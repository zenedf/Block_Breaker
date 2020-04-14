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
    #region Tutorial Code

    // Configuration Parameters
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] TextMeshProUGUI txtScore;
    [SerializeField] TextMeshProUGUI txtBlockCount;
    SceneLoader sceneLoader;

    // TESTING
    int updateCounter;

    // State Variables
    [SerializeField] int currentScore = 0;
    [SerializeField] int blocksLeft = 0;

    [SerializeField] private bool isPausable_GameSession;

    //[SerializeField] int counts_updates_from_sceneLoader_to_gameSession;

    /// <summary>
    /// TODO
    /// </summary>
    void Awake()
    {
        //Debug.Log("GameSession.Awake()");


        // Get a count of how many 'GameSession' objects there are in the current scene
        int _gameStatusCount = FindObjectsOfType<GameSession>().Length;

        // If there's already more than 1, destroy yourself
        if (_gameStatusCount > 1)
        {
            // Put this line of code right before 'Destroy' if we're using the Singleton pattern to avoid bugs.
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else // If there's not already more than one, don't destroy when the level loads in the future.
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    /// <summary>
    /// TODO
    /// </summary>
    private void Start()
    {
        //Debug.Log("GameSession.Start()");


        //counts_updates_from_sceneLoader_to_gameSession = 0;

        sceneLoader = FindObjectOfType<SceneLoader>();

        txtScore.text = currentScore.ToString();

        //isPausable_GameSession = sceneLoader.isPausable;

        // This is for testing the pause button
        //txtScore.text = Time.timeScale.ToString();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        //Debug.Log("GameSession.Update()");


        // This is for testing the pause button
        // txtScore.text = Time.timeScale.ToString();

        // If the player has pressed the escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // sceneLoader = FindObjectOfType<SceneLoader>();
            // isPausable_GameSession = sceneLoader.isPausable;

            // If the player is able to pause or resume
            // if (isPausable_GameSession == true)
            //if (sceneLoader.isPausable == true)
            //{
            //    // If the game is currently paused
            //    if (Time.timeScale == 0)
            //    {
            //        // Resume the game
            //        sceneLoader.ResumeTheGame();
            //    }
            //    else
            //    {
            //        // Pause the game
            //        sceneLoader.PauseTheGame(true);
            //    }
            //}
        }

        // Uncomment this after finished testing the pause button
        Time.timeScale = gameSpeed;

        // If the game wasn't paused from another location, keep updating the time with gameSpeed
        //if (Time.timeScale != 0)
        //{
        //    //Debug.Log("GameSession.Update, Time.timeScale is " + Time.timeScale);
        //    Time.timeScale = gameSpeed;
        //    //Debug.Log("GameSession.Update, Time.timeScale = gameSpeed is " + Time.timeScale);
        //}
    }

    /// <summary>
    /// TODO
    /// </summary>
    public void AddToScore()
    {
        //Debug.Log("GameSession.AddToScore()");


        currentScore += pointsPerBlockDestroyed;
        // Uncomment this after finished testing the pause button
        txtScore.text = currentScore.ToString();
    }

    /// <summary>
    /// TODO
    /// </summary>
    public void UpdateBlockData()
    {
        //Debug.Log("GameSession.UpdateBlockData()");


        blocksLeft = FindObjectOfType<Level>().GetNumberOfBreakableBlocks(); // TESTING

        txtBlockCount.text = blocksLeft.ToString(); // TESTING
    }

    /// <summary>
    /// TODO
    /// </summary>
    public void ResetGameStats()
    {
        //Debug.Log("GameSession.ResetGameStats()");


        //currentScore = 0;
        //scoreText.text = "";

        Destroy(gameObject);
    }

    #endregion Tutorial Code
}
