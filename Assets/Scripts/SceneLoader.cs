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

    /// <summary>
    /// This creates a list of 'GameObjects' by iterating through each object in the current scene
    /// </summary>
    //void ListAllGameObjectsInCurrentScene()
    //{
    //    // Initializing a list of blank objects.
    //    List<GameObject> _rootObjects = new List<GameObject>();


    //    // Getting the current active scene.
    //    Scene _scene = SceneManager.GetActiveScene();


    //    // Returns a list of root game objects in the current scene.
    //    _scene.GetRootGameObjects(_rootObjects);


    //    // Traverse the list of root game objects
    //    for (int i = 0; i < _rootObjects.Count; i++)
    //    {
    //        // Convert each 'rootObject' to a 'GameObject' one by one
    //        GameObject _gameObj = _rootObjects[i];


    //        // Print the current 'GameObject' in the list inside the debug console
    //        Debug.Log(_gameObj);
    //    }
    //}
}
