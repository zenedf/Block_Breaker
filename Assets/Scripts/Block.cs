///TODO
///[ ] Make this into a reusable code base for a breakable object in your game.

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// This handles the block logic
/// </summary>
public class Block : MonoBehaviour
{
    // This will be the sound played when a block breaks
    //[SerializeField] AudioClip breakSound;

    GameSession GameSession;
    Level Level;

    /// <summary>
    /// This run when a block is instantiated and is used to count the blocks
    /// </summary>
    private void Start()
    {
        // Initialize components
        GameSession = FindObjectOfType<GameSession>();
        Level = FindObjectOfType<Level>();

        Level.CountBreakableBlocks();

        //GameSession.GetComponent<GameSession>().UpdateBlockData(Level);
        GameSession.UpdateBlockData(Level);
    }

    /// <summary>
    /// When a ball makes contact with a block, the block gets destroyed.
    /// </summary>
    /// <param name="_collision">The object that the ball collided with</param>
    private void OnCollisionEnter2D(Collision2D _collision)
    {
        // When the ball collides with the block, destroy the block
        DestroyBlock();
    }

    /// <summary>
    /// This adds to the final score and destroys the current block that has been hit.
    /// </summary>
    private void DestroyBlock()
    {
        // This is what they showed in the tutorials
        //FindObjectOfType<GameSession>().AddToScore();
        GameSession.AddToScore();

        // Play a certain sound at the position of the main camera in your game
        //AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        // I hate the sounds on this game. That's why the above line is commented out

        // Destroys the game object this script is attached to on collision.
        // In this case, it's a block.
        Destroy(gameObject);

        this.Level.BlockDestroyed();
        // Decrease the block counter by one
        // Check to see if there are any more blocks left in the current level

        GameSession.UpdateBlockData();
    }
}
