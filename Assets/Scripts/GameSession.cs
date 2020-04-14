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

    // State Variables
    [SerializeField] int currentScore = 0;
    [SerializeField] int blocksLeft = 0;

    /// <summary>
    /// TODO
    /// </summary>
    void Awake()
    {
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
        txtScore.text = currentScore.ToString(); // Tutorial
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        //blocksLeft = level.GetNumberOfBreakableBlocks(); // THIS WORKS!!!

        Time.timeScale = gameSpeed;
    }

    /// <summary>
    /// TODO
    /// </summary>
    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        txtScore.text = currentScore.ToString();
    }


    /// <summary>
    /// TODO
    /// </summary>
    public void UpdateBlockData()
    {
        blocksLeft = FindObjectOfType<Level>().GetNumberOfBreakableBlocks(); // TESTING

        txtBlockCount.text = blocksLeft.ToString(); // TESTING
    }

    /// <summary>
    /// TODO
    /// </summary>
    public void ResetGameStats()
    {
        //currentScore = 0;
        //scoreText.text = "";

        Destroy(gameObject);
    }

    /// <summary>
    /// TODO
    /// </summary>
    //public void TurnOnNextLevelButton()
    //{
    //    //FindObjectOfType<Button>().gameObject.SetActive(true);

    //    Button btn = GameObject.Find("GameSession/GameCanvas/btnNextLevel").GetComponent<Button>();
    //    btn.gameObject.SetActive(true);
    //}

    #endregion Tutorial Code
}
