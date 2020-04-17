///TODO
///[ ] 'LaunchMouseOnClick' method launches the ball a little bit to the right no matter what.
///     If moving right at all, shoot ball right. If moving left at all, shoot ball right. Shoot right if stationary.
///[x] Add a method that detects the ball's speed.
///[ ] If the pause menu is on and you click anywhere, then you turn the pause menu off by pressing the escape key, the ball will shoot as soon as the pause menu goes away.
///     I think you need to not allow the code in the 'Ball.Update' method to run if the pause menu is activated.
///[ ] Display the average speed of both

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

    #endregion Configuration Parameters

    #region States

    // An object reference to use the Conversion classes methods
    Conversions conversions = new Conversions();

    // A Vector2 that will used to calculate the distance between the paddle and the ball.
    Vector2 paddleToBallVector;

    // Has the player shot yet?
    public bool hasShot = false;

    #endregion States

    // Cached component references
    AudioSource myAudioSource;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // The current 'ball' vector minus the current 'paddle' vector.
        paddleToBallVector = transform.position - paddle1.transform.position;

        // Initialize the cached audio component
        myAudioSource = GetComponent<AudioSource>();
    }


    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
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

    /// <summary>
    /// Return current ball speed in meters per second
    /// </summary>
    public int GetSpeedInMPS()
    {
        return (int)speedInMetersPerSecond;
    }


    /// <summary>
    /// Return current ball speed in miles per hour
    /// </summary>
    public int GetSpeedInMPH()
    {
        return (int)speedInMilesPerHour;
    }


    /// <summary>
    /// Return the highest speed your ball has reached in meters per second for the particular game session
    /// </summary>
    public int GetHighestSpeedInMPS()
    {
        return (int)highestSpeedInMps;
    }


    /// <summary>
    /// Return the highest speed your ball has reached in miles per hour for the particular game session
    /// </summary>
    public int GetHighestSpeedInMPH()
    {

        return (int)highestSpeedInMph;
    }

    #endregion Speed Getters

    /// <summary>
    /// Update the speed information and display it.
    /// </summary>
    public void DisplaySpeeds()
    {
        UpdateSpeeds();
    }


    /// <summary>
    /// Display the speeds in the serialized fields
    /// </summary>
    private void UpdateSpeeds()
    {
        // Update the speed in Meters Per Second every frame
        // (Unity Units per second are roughly the equivalent to Meters Per Second)
        // The code below returns how many Unity Units Per Second the 'Rigidbody2D' is traveling.
        speedInMetersPerSecond = GetComponent<Rigidbody2D>().velocity.magnitude;

        // If the balls current speed is less than 10.0 meters per second
        if (speedInMetersPerSecond < 10f)
        {
            // Do something to keep the ball from going too slow
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
    }


    /// <summary>
    /// Display the your final speed stats at the end of the game session
    /// </summary>
    public void DisplayFinalSpeeds()
    {
        //Debug.Log("Highest speed in MPS = " + highestSpeedInMps);
        //Debug.Log("Highest speed in MPH = " + highestSpeedInMph);
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
            #endregion Playing a block break sound
        }
    }
}


/// <summary>
/// This class contains conversion methods.
/// </summary>
public class Conversions
{
    /// <summary>
    /// Ths takes in distance and time to calculate velocity in meters per second
    /// </summary>
    /// <param name="_meters">distance in meters</param>
    /// <param name="_time">time in seconds</param>
    /// <returns>returns the velocity/speed depending on your inputs</returns>
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
    /// <returns>s</returns>
    public float MpsToMph(float _velocity)
    {
        float _mph = 0f;
        float _mps = _velocity;

        _mph = _mps * 2.2369f;

        return _mph;
    }
}
