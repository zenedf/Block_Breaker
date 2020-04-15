using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TODO
/// </summary>
public class Block : MonoBehaviour
{
    #region Tutorial Code

    // I commented this out because I hate the sounds on the game
    //[SerializeField] AudioClip breakSound;

    // cached reference
    Level level; // Tutorial Code

    /// <summary>
    /// This is a much easier way of counting the current blocks on the screen
    /// This was shown to me on a tutorial
    /// </summary>
    private void Start()  // Comment this out later.This is just an example.
    {
        // Holy cow I can't believe it was that easy to do this programmatically.
        // I approached this all wrong and after a long time of not being able to figure it out I gave up and put certain things in the same script.
        level = FindObjectOfType<Level>(); // Tutorial Code
        //gameSession = FindObjectOfType<GameSession>();

        level.CountBreakableBlocks(); // Tutorial Code

        #region BAD CODE!!! Keep it to learn from mistakes.
        // This code caused the remaining bricks to always be at zero after the first level.
        //FindObjectOfType<GameSession>().UpdateBlockData(); // TESTING
        // Was it because I called the UpdateBlockData()? or was it because I instantiated it at that particular spot?
        // Who knows??
        #endregion
    }

    #endregion Tutorial Code

    /// <summary>
    /// When a ball makes contact with a block, the block gets destroyed.
    /// </summary>
    /// <param name="_collision">The object that the ball collided with</param>
    private void OnCollisionEnter2D(Collision2D _collision)
    {
        //Debug.Log("Block.OnCollisionEnter2D(Collision2D _collision)");


        #region Testing purposes
        // This is for testing purposes.
        // This prints the name of the object that is colliding with this(Block) object.
        //Debug.Log(collision.gameObject.name);
        #endregion

        // When the ball collides with the block, destroy the block
        DestroyBlock();
    }


    #region Tutorial Code
    /// <summary>
    /// TODO
    /// </summary>
    private void DestroyBlock()
    {
        //Debug.Log("Block.DestroyBlock()");


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

        //FindObjectOfType<GameSession>().UpdateBlockData(); // TESTING
        // I might be scrapping that too!
    }

    #endregion Tutorial Code
}