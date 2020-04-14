using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Code that handles the level logic
/// </summary>
public class Level : MonoBehaviour
{
    #region Tutorial Code

    // Configuration Parameters
    [SerializeField] int breakableBlocks; // Serialized for debugging purposes

    // Cached Reference
    SceneLoader sceneLoader;

    /// <summary>
    /// Start method
    /// </summary>
    private void Start()
    {
        //Debug.Log("Level.Start()");


        // This confines the cursor to the game menu
        Cursor.lockState = CursorLockMode.Confined;
        // I don't know if this will disable player movement.

        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    /// <summary>
    /// Each time this is called, we want to add one more breakable block to the total number of breakable blocks
    /// </summary>
    public void CountBreakableBlocks()
    {
        //Debug.Log("Level.CountBreakableBlocks()");


        breakableBlocks++;
    }

    /// <summary>
    /// When a block is destroyed we want the counter to decrease the number of blocks by 1
    /// </summary>
    public void BlockDestroyed()
    {
        //Debug.Log("Level.BlockDestroyed()");


        breakableBlocks--;

        if (breakableBlocks <= 0)
        {
            //sceneLoader.LoadNextScene();
            sceneLoader.NextLevelAndQuitButtons();
        }
    }

    /// <summary>
    /// TODO
    /// </summary>
    /// <returns></returns>
    public int GetNumberOfBreakableBlocks()
    {
        //Debug.Log("Level.GetNumberOfBreakableBlocks()");


        return breakableBlocks;
    }

    #endregion Tutorial Code
}
