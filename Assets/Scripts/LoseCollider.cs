///TODO
///[ ] This is code that you can always use as lose condition when falling too far.

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
    SceneLoader loader;

    /// <summary>
    /// As soon as a scene loads with a LoseCollider object in it, this runs.
    /// This runs before the start method.
    /// </summary>
    private void Awake()
    {
        // Adds a Component class of type 'componentType' to the game object.
        // Generic version
        loader = gameObject.AddComponent<SceneLoader>() as SceneLoader;
    }

    /// <summary>
    /// When the player's ball drops below a certain height in the level, the 'GameOver' scene is loaded.
    /// </summary>
    /// <param name="collision">The collision between an incoming collider and this object's collider.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // This loads the GameOver scene.
        loader.LoadGameOverScene();
    }
}
