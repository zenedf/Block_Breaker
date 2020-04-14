﻿///TODO
///[ ] 'LaunchMouseOnClick' method launches the ball a little bit to the right no matter what.
///     If moving right at all, shoot ball right. If moving left at all, shoot ball right. Shoot right if stationary.
///[x] Add a method that detects the ball's speed.
///[ ] If the pause menu is on and you click anywhere, then you turn the pause menu off by pressing the escape key, the ball will shoot as soon as the pause menu goes away.
///     I think you need to not allow the code in the 'Ball.Update' method to run if the pause menu is activated.

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

    // Meters per Second (Unity Units per second are roughly the equivalent to Meters Per Second)
    [SerializeField] float speedInMetersPerSecond;

    // Miles Per Hour
    [SerializeField] float speedInMilesPerHour;

    // Keeps track of the highest speed in Meters Per Second
    [SerializeField] float highestSpeedInMps;

    // Keeps track of the highest speed in Miles Per Hour
    [SerializeField] float highestSpeedInMph;

    // An array of sound files
    [SerializeField] AudioClip[] ballSounds;

    #endregion

    #region States

    // An object reference to use the conversions methods
    Conversions conversions = new Conversions();

    // A Vector2 that will used to calculate the distance between the paddle and the ball.
    Vector2 paddleToBallVector;

    // Has the player shot yet?
    public bool hasShot = false;
    #endregion

    // Cached component references
    AudioSource myAudioSource;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        //Debug.Log("Ball.Start()");


        // The current 'ball' vector minus the current 'paddle' vector.
        paddleToBallVector = transform.position - paddle1.transform.position;

        myAudioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        //Debug.Log("Ball.Update()");


        // If the player hasn't shot the ball yet
        if (hasShot == false)
        {
            // Lock the ball to the paddle
            LockBallToPaddle();

            // Shoot the ball when the player clicks the mouse button.
            LaunchOnMouseClick();
        }
        else if (hasShot == true) // If the game has begun
        {
            // Display speed in mps and mph
            DisplaySpeeds();
        }
    }

    #region Speed Getters
    public int GetSpeedInMPS()
    {
        //Debug.Log("Ball.GetSpeedInMPS()");


        return (int)speedInMetersPerSecond;
    }

    public int GetSpeedInMPH()
    {
        //Debug.Log("Ball.GetSpeedInMPH()");


        return (int)speedInMilesPerHour;
    }

    public int GetHighestSpeedInMPS()
    {
        //Debug.Log("Ball.GetHighestSpeedInMPS()");


        return (int)highestSpeedInMps;
    }

    public int GetHighestSpeedInMPH()
    {
        //Debug.Log("Ball.GetHighestSpeedInMPH()");


        return (int)highestSpeedInMph;
    }
    #endregion

    public void DisplaySpeeds()
    {
        //Debug.Log("Ball.DisplaySpeeds()");


        UpdateSpeeds();

        // Then displays them.
    }

    /// <summary>
    /// Display the speeds in the serialized fields
    /// </summary>
    private void UpdateSpeeds()
    {
        //Debug.Log("Ball.UpdateSpeeds()");


        // Update the speed in Meters Per Second every frame
        // (Unity Units per second are roughly the equivalent to Meters Per Second)
        // The code below returns how many Unity Units Per Second the 'Rigidbody2D' is traveling.
        speedInMetersPerSecond = GetComponent<Rigidbody2D>().velocity.magnitude;

        // If the balls current speed is less than 10.0 meters per second
        if (speedInMetersPerSecond < 10f)
        {
            // Do something to keep the ball from going to slow
        }

        // If the current mps is greater than or equal to the highest mps speed so far, update the highest speed.
        if (speedInMetersPerSecond >= highestSpeedInMps)
        {
            highestSpeedInMps = GetComponent<Rigidbody2D>().velocity.magnitude;
        }

        // Update the speed in Miles Per Hour every frame
        speedInMilesPerHour = conversions.MpsToMph(GetComponent<Rigidbody2D>().velocity.magnitude);

        // If the current mph is greater than or equal to the highest mph speed so far, update the highest speed.
        if (speedInMilesPerHour >= highestSpeedInMph)
        {
            highestSpeedInMph = conversions.MpsToMph(GetComponent<Rigidbody2D>().velocity.magnitude);
        }

        //TODO
        //[ ] Display the average speed on both

    }

    /// <summary>
    /// TESTING
    /// </summary>
    public void DisplayFinalSpeeds()
    {
        //Debug.Log("Ball.DisplayFinalSpeeds()");


        //Debug.Log("Highest speed in MPS = " + highestSpeedInMps);
        //Debug.Log("Highest speed in MPH = " + highestSpeedInMph);
    }

    /// <summary>
    /// Launches the ball whenver the user wants to start the game.
    /// </summary>
    private void LaunchOnMouseClick()
    {
        //Debug.Log("Ball.LaunchOnMouseClick()");


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
        //Debug.Log("Ball.LockBallToPaddle()");


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
        //Debug.Log("Ball.OnCollisionEnter2D(Collision2D collision)");


        // If the player has initiated the game by shooting the ball
        if (hasShot == true)
        {
            //GetComponent<AudioSource>().Play();
            // 'PlayOneShot' means that it will play a sound all the way through without being interrupted.
            //GetComponent<AudioSource>().PlayOneShot(clip);

            #region Playing a block break sound
            // This creates a variable of an array of audio clips ranging from the first audio clip to the last in the array
            //AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];

            //myAudioSource.PlayOneShot(clip);
            #endregion
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