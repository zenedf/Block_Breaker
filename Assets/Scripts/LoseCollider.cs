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
    //private SceneLoader loader = new SceneLoader(); // The 'new' keyword is not allowed for monobehaviour

    //private SceneLoader loader;

    SceneLoader loader;

    private void Awake()
    {
        //Debug.Log("LoseCollider.Awake()");


        //loader = FindObjectOfType<SceneLoader>();


        // Adds a Component class of type 'componentType' to the game object.
        //loader = gameObject.AddComponent(typeof(SceneLoader)) as SceneLoader;

        // Generic version
        loader = gameObject.AddComponent<SceneLoader>() as SceneLoader;
    }

    /// <summary>
    /// When the player's ball drops below a certain height in the level, the 'GameOver' scene is loaded.
    /// </summary>
    /// <param name="collision">The collision between an incoming collider and this object's collider</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("LoseCollider.OnTriggerEnter2D(Collider2D collision)");


        // This loads the GameOver scene
        loader.LoadGameOverScene();

    }
}