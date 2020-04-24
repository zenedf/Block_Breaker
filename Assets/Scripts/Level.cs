using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Code that handles the level logic
/// </summary>
public class Level : MonoBehaviour
{
    // Configuration Parameters

    // Serialized for debugging purposes
    [SerializeField] int breakableBlocks;

    // Cached Reference

    // Create a cached reference for the SceneLoader.cs script.
    // This is so you can use the methods in the SceneLoader.cs script.
    SceneLoader sceneLoader;
    
    /// <summary>
    /// Start method
    /// </summary>
    private void Start()
    {
        // This confines the cursor to the game menu
        //Cursor.lockState = CursorLockMode.Confined; // TESTING
        // I don't know if this will disable player movement though.

        // Initialize the SceneLoader.cs script variable
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    /// <summary>
    /// Each time this is called, we want to add one more breakable block to the total number of breakable blocks
    /// </summary>
    public void CountBreakableBlocks()
    {
        // Add one to the current number of breakableBlocks
        breakableBlocks++;
    }

    /// <summary>
    /// When a block is destroyed we want the counter to decrease the number of blocks by 1
    /// </summary>
    public void BlockDestroyed()
    {
        // Add one to the current number of breakableBlocks
        breakableBlocks--;

        // If the number of breakableBlocks in the level reach zero
        if (breakableBlocks <= 0)
        {
            // Activate the NextLevel button and the QuitGame button
            sceneLoader.NextLevelAndQuitButtons();
        }
    }

    /// <summary>
    /// This will give the current number of breakableBlocks in the level
    /// </summary>
    /// <returns>The number of breakableBlocks</returns>
    public int GetNumberOfBreakableBlocks()
    {
        return breakableBlocks;
    }
}
