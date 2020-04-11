using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // parameters
    [SerializeField] int breakableBlocks; // Serialized for debugging purposes

    // cached reference
    SceneLoader sceneLoader;

    /// <summary>
    /// Start method
    /// </summary>
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    /// <summary>
    /// Each time this is called, we want to add one more breakable block to the total number of breakable blocks
    /// </summary>
    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    /// <summary>
    /// When a block is destroyed we want the counter to decrease the number of blocks by 1
    /// </summary>
    public void BlockDestroyed()
    {
        breakableBlocks--;
        //if (breakableBlocks <= 0)
        //{
        //    sceneLoader.LoadNextScene();
        //}
    }
}
