using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This is from the tutorial
/// </summary>
public class GameSession : MonoBehaviour
{
    #region Tutorial Code

    // config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;

    // state variables
    [SerializeField] int currentScore = 0;

    

    private void Awake()
    {
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
        scoreText.text = currentScore.ToString();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    /// <summary>
    /// TODO
    /// </summary>
    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
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


    #endregion Tutorial Code
}
