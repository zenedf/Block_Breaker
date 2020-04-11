///TODO
///[ ] 'LaunchMouseOnClick' method launches the ball a little bit to the right no matter what.
///     If moving right at all, shoot ball right. If moving left at all, shoot ball right. Shoot right if stationary.
///[x] Add a method that detects the ball's speed.

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

    // Meters per Second
    [SerializeField] float speedInUnitsPerSecond;

    // Miles Per Hour
    [SerializeField] float speedInMilesPerHour;

    // Keeps track of the highest speed in Meters Per Second
    [SerializeField] float highestSpeedInMps;

    // Keeps track of the highest speed in Miles Per Hour
    [SerializeField] float highestSpeedInMph;

    #endregion


    #region States

    // An object reference to use the conversions methods
    Conversions conversions = new Conversions();

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
        else if (hasShot) // If the game has begun
        {
            // Display speed in mps and mph
            DisplaySpeeds();
        }
    }


    public void DisplaySpeeds()
    {
        UpdateSpeeds();

        // Then displays them.
    }

    /// <summary>
    /// Display the speeds in the serialized fields
    /// </summary>
    private void UpdateSpeeds()
    {
        // Update the speed in Meters Per Second every frame
        speedInUnitsPerSecond = GetComponent<Rigidbody2D>().velocity.magnitude;

        if (speedInUnitsPerSecond < 10f)
        {
            // TESTING
            Debug.Log("Speed in MPS = " + speedInUnitsPerSecond);
        }

        // If the current mps is greater than or equal to the highest mps speed so far, update the highest speed.
        if (speedInUnitsPerSecond >= highestSpeedInMps)
        {
            highestSpeedInMps = GetComponent<Rigidbody2D>().velocity.magnitude;

            // TESTING
            //Debug.Log("Highest speed in MPS = " + highestSpeedInMps);
        }

        // Update the speed in Miles Per Hour every frame
        speedInMilesPerHour = conversions.MpsToMph(GetComponent<Rigidbody2D>().velocity.magnitude);

        // TESTING
        //Debug.Log("Speed in MPH = " + speedInMilesPerHour);

        // If the current mph is greater than or equal to the highest mph speed so far, update the highest speed.
        if (speedInMilesPerHour >= highestSpeedInMph)
        {
            highestSpeedInMph = conversions.MpsToMph(GetComponent<Rigidbody2D>().velocity.magnitude);

            // TESTING
            //Debug.Log("Highest speed in MPH = " + highestSpeedInMph);
        }

        //TODO
        //[ ] Display the average speed on both

    }

    /// <summary>
    /// TESTING
    /// </summary>
    public void DisplayFinalSpeeds()
    {
        Debug.Log("Highest speed in MPS = " + highestSpeedInMps);
        Debug.Log("Highest speed in MPH = " + highestSpeedInMph);
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

    /// <summary>
    /// Whenever the ball collides with an object, a sound will play.
    /// </summary>
    /// <param name="collision">The object that the current object collided with</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasShot)
        {
            GetComponent<AudioSource>().Play();
        }
    }

}

/// <summary>
/// This class contains conversion methods.
/// </summary>
public class Conversions
{
    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="_meters"></param>
    /// <param name="_seconds"></param>
    /// <param name="_distance"></param>
    /// <param name="_time"></param>
    /// <returns></returns>
    //public float MetersPerSecond(float _meters, float _seconds, float _distance, float _time)
    //{
    public float MetersPerSecond(float _meters, float _seconds)
    {
        // Meters per second
        float _velocity = 0f;

        _velocity = _meters / _seconds;
        // Speed  = Distance / Time

        return _velocity;
    }

    /// <summary>
    /// This returns the conversion from meters per second to miles per hour
    /// </summary>
    /// <param name="_meters">Distance in meters</param>
    /// <param name="_time">Time in seconds</param>
    /// <returns>The velocity in miles per hour</returns>
    public float MpsToMph(float _meters, float _second)
    {
        float _mph = 0f;
        float _mps = 0f;

        _mps = MetersPerSecond(_meters, _second);

        _mph = _mps * 2.2369f;

        return _mph;
    }

    /// <summary>
    /// This returns the conversion from meters per second to miles per hour
    /// </summary>
    /// <param name="_meters"></param>
    /// <param name="_time"></param>
    /// <returns></returns>
    public float MpsToMph(float _velocity)
    {
        float _mph = 0f;
        float _mps = _velocity;

        _mph = _mps * 2.2369f;

        return _mph;
    }
}