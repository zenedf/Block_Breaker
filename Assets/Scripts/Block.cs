using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This handles the block logic
/// </summary>
public class Block : MonoBehaviour
{
    #region Cached References
    // This is so I can use the Level object with the scripts and methods attached to it.
    Level level;

    // This will be the sound played when a block breaks
    //[SerializeField] AudioClip breakSound;
    #endregion

    /// <summary>
    /// This run when a block is instantiated and is used to count the blocks
    /// </summary>
    private void Start()
    {
        level = FindObjectOfType<Level>(); // Tutorial Code
        //gameSession = FindObjectOfType<GameSession>();

        level.CountBreakableBlocks();

        #region BAD CODE!!! Keep it to learn from mistakes.
        // This code caused the remaining bricks to always be at zero after the first level.
        //FindObjectOfType<GameSession>().UpdateBlockData(); // TESTING
        // Was it because I called the UpdateBlockData()? or was it because I instantiated it at that particular spot?
        // Who knows??
        #endregion
    }


    /// <summary>
    /// When a ball makes contact with a block, the block gets destroyed.
    /// </summary>
    /// <param name="_collision">The object that the ball collided with</param>
    private void OnCollisionEnter2D(Collision2D _collision)
    {
        #region Testing purposes
        // This prints the name of the object that is colliding with this(Block) object.
        //Debug.Log(collision.gameObject.name);
        #endregion

        // When the ball collides with the block, destroy the block
        DestroyBlock();
    }


    /// <summary>
    /// This adds to the final score and destroys the current block that has been hit.
    /// </summary>
    private void DestroyBlock()
    {
        // This is what they showed in the tutorials
        FindObjectOfType<GameSession>().AddToScore();

        // Play a certain sound at the position of the main camera in your game
        //AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        // I hate the sounds on this game. That's why the above line is commented out

        // Destroys the game object this script is attached to on collision.
        // In this case, it's a block.
        Destroy(gameObject);

        // Decrease the block counter by one
        // Check to see if there are any more blocks left in the current level
        level.BlockDestroyed();

        #region This caused issues
        //FindObjectOfType<GameSession>().UpdateBlockData();
        #endregion
    }
}
