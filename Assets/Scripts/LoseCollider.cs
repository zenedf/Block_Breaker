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
    private SceneLoader loader = new SceneLoader();

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