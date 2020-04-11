using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class provides a lose condition
/// </summary>
public class LoseCollider : MonoBehaviour
{
    // Creates a 'SceneLoader' to load a scene using this script.
    SceneLoader loader = new SceneLoader();


    //// TESTING
    //Scene currentScene = new Scene();

    //// TESTING
    //Ball ball = new Ball();
    //// This is initialized with all the variables as their defaults and it does not update the variables during gameplay.
    //// Figure out a way to update the variables while the game is running so that we can display final variable values in this current script.

    #region Pause Method Testing
    //// TESTING
    //[SerializeField] private GameObject pauseCanvas;
    #endregion

    /// <summary>
    /// When the player's ball drops below a certain height in the level, the 'GameOver' scene is loaded.
    /// </summary>
    /// <param name="collision">The collision between an incoming collider and this object's collider</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // This loads the GameOver scene
        loader.LoadGameOverScene();


        // TESTING
        //ball.DisplayFinalSpeeds();

        // THIS DOESN'T WORK!!!
        #region Pause Method Testing
        // TESTING
        //PauseGame();

        // TESTING
        //loader.PauseGame();
        #endregion
    }

    /// <summary>
    /// This works, but calling the 'PauseGame' method from another script doesn't work.
    /// It makes the 'pauseCanvas' GameObject value null.
    /// </summary>
    //private void PauseGame()
    //{
    //    Time.timeScale = 0;

    //    pauseCanvas.SetActive(true);


    //    // These don't work.
    //    #region Pause Method Testing
    //    //loader.PauseGame();

    //    // TESTING
    //    //loader.PauseGame();

    //    //currentScene = SceneManager.GetActiveScene();

    //    //Debug.Log(currentScene.name); // This returns null
    //    #endregion
    //}

    // TESTING
    //public bool GameHasEnded()
    //{
    //    return true;
    //}
}