using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TODO
/// </summary>
public class Block : MonoBehaviour
{
    //[SerializeField] AudioClip breakSound;

    // cached reference
    //Level level; // This was also from the tutorial

    /// <summary>
    /// This is a much easier way of counting the current blocks on the screen
    /// This was shown to me on a tutorial
    /// </summary>
    private void Start()  // Comment this out later.This is just an example.
    {
        // Holy cow I can't believe it was that easy to do this programmatically.
        // I approached this all wrong and after a long time of not being able to figure it out I gave up and put certain things in the same script.
        //level = FindObjectOfType<Level>();

        //level.CountBreakableBlocks();
    }

    /// <summary>
    /// When a ball makes contact with a block, the block gets destroyed.
    /// </summary>
    /// <param name="collision">The object that the ball collided with</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        #region Testing purposes
        // This is for testing purposes.
        // This prints the name of the object that is colliding with this(Block) object.
        //Debug.Log(collision.gameObject.name);
        #endregion

        // Destroy gameObject with a one second delay
        //Destroy(gameObject, 1f);

        #region My attempt at finding the camera in the scene
        //GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        ////AudioSource.PlayClipAtPoint(breakSound, new Vector3(5, 1, 2));
        //AudioSource.PlayClipAtPoint(breakSound, cam.transform.position);
        #endregion

        // Play a certain sound at the position of the main camera in your game
        //AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);


        // Destroys the game object this script is attached to on collision.
        // In this case, it's a block.
        Destroy(gameObject);


        // This is a much much better way of doing things, but I got it from a tutorial.
        //level.BlockDestroyed();


        // In the tutorial they said to put all of the code that's in this current method into a new method and then call the new method right here.
        // Not going to do that though :P
        //DestroyBlock();        
    }

    /// <summary>
    /// Tutorial
    /// </summary>
    private void DestroyBlock()
    {
        FindObjectOfType<GameStatus>().AddToScore();

        //AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        //Destroy(gameObject);
        //level.BlockDestroyed;
        //level.AddToScore();
    }
}