using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="collision">TODO</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);


        // This prints the name of the object that is colliding with this(Block) object.
        //Debug.Log(collision.gameObject.name);
    }
}
