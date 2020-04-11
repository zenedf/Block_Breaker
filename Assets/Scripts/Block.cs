using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TODO
/// </summary>
public class Block : MonoBehaviour
{
    /// <summary>
    /// When a ball makes contact with a block, the block gets destroyed.
    /// </summary>
    /// <param name="collision">The object that the ball collided with</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        // This is for testing purposes.
        // This prints the name of the object that is colliding with this(Block) object.
        //Debug.Log(collision.gameObject.name);
    }
}