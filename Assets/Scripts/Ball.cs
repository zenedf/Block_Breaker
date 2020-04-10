///TODO
///[ ] 'LaunchMouseOnClick' method launches the ball a little bit to the right no matter what.
///     If moving right at all, shoot ball right. If moving left at all, shoot ball right. Shoot right if stationary.
///[ ] Add a method that detects the ball's speed.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles the ball.
/// </summary>
public class Ball : MonoBehaviour
{
    #region Configuration Parameters
    // This is used to tell which paddle we are using in reference to this ball.
    [SerializeField] Paddle paddle1;


    // Pushes something 2f unity units to the right.
    [SerializeField] float xPush = 2f;


    // Pushes something 15f unity units per second upward.
    [SerializeField] float yPush = 15f;
    #endregion


    #region States
    // A Vector2 that will used to calculate the distance between the paddle and the ball.
    Vector2 paddleToBallVector;


    // Has the player shot yet?
    bool hasShot = false;
    #endregion

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // The current 'ball' vector minus the current 'paddle' vector.
        paddleToBallVector = transform.position - paddle1.transform.position;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // If the player hasn't shot the ball yet
        if (!hasShot)
        {
            // Lock the ball to the paddle
            LockBallToPaddle();


            // Shoot the ball when the player clicks the mouse button.
            LaunchOnMouseClick();
        }
    }

    /// <summary>
    /// Launches the ball whenver the user wants to start the game.
    /// </summary>
    private void LaunchOnMouseClick()
    {
        // If the user clicks the primary(left) mouse button.
        if (Input.GetMouseButtonDown(0))
        {
            // Register that the player has indeed shot.
            hasShot = true;


            // Shoot the ball 2f units to the right at 15f units per second upward.
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    /// <summary>
    /// Sticks the ball to the paddle and keeps it there.
    /// </summary>
    private void LockBallToPaddle()
    {
        // The current X and Y position of the paddle.
        Vector2 _paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);


        // Add the current X and Y paddle positions with the distance between the two Y coordinates of the paddle and ball.
        transform.position = _paddlePosition + paddleToBallVector;
    }
}
