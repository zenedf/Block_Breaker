using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This handles the scene controls.
/// </summary>
public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// This loads the next scene based on it's index.
    /// </summary>
    public void LoadNextScene()
    {
        // Creates an index of the current active scenes in the 'Edit -> BuildSettings' in Unity
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Loads the next scene in the list.
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    /// <summary>
    /// This loads the first scene in the 'Edit -> BuildSettings'
    /// </summary>
    public void LoadStartScene()
    {
        // Loads the first/intro/start scene.
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// This loads the scene titled 'GameOver', regardles off what index it is at in 'Edit -> BuildSettings'
    /// </summary>
    public void LoadGameOverScene()
    {
        // Loads the 'GameOver' scene.
        SceneManager.LoadScene("GameOver");
    }

    /// <summary>
    /// This closes the application
    /// </summary>
    public void Quit()
    {
        // Closes the current application you are running.
        Application.Quit();
    }
}
