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

    #region TESTING
    //// This is initialized with all the variables as their defaults and it does not update the variables during gameplay.
    //// Figure out a way to update the variables while the game is running so that we can display final variable values in this current script.

    //Scene currentScene;
    //Ball ball;

    //private void Start()
    //{
    //    ball.GetComponent<Ball>();
    //    currentScene.GetPhysicsScene2D();
    //}
    #endregion

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

    }
}