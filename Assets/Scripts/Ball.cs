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
    #endregion


    // TESTING
    [SerializeField] float speedInUnitsPerSecond;
    // Meters per Second


    // TESTING
    [SerializeField] float speedInMilesPerHour;


    // TESTING
    [SerializeField] float highestSpeedInMps = 0f;


    // TESTING
    [SerializeField] float highestSpeedInMph = 0f;


    // TESTING
    Conversions conversions = new Conversions();


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
        else if (hasShot)
        {
            // Display speed in mps and mph
            DisplaySpeeds();


            //// Velocity = Distance / Time

            //// Say speed is 6. That's 6 unity units/s.
            //// You have a conversion of 1 meter = 1 unit
            //// 1 m = 3.3 feet so then (6 * 3.33) is 19.69 feet/s
            //// There is 3600 seconds in an hour. So, if you travel at 6 m/s then that converts to 21.6 km/h
            //// At ~1.6 km/h per 1 mile/h, 6 m/s is 34.56 miles/h

            //speedInUnitsPerSecond = GetComponent<Rigidbody2D>().velocity.magnitude;

            //// (units/s) * (3.33 feet) = feet/s
            //// 3600 seconds in an hour.     6 meters/second * 3.6 = 21.6 kilometers/hour
            ////                              1 meter/second * 3.6 = 3.6 kilometers/hour
            //// ~1.6 km/h per 1 mile/h

        }
    }

    /// <summary>
    /// Display the speeds in the serialized fields
    /// </summary>
    private void DisplaySpeeds()
    {
        // Update the speed in Meters Per Second every frame
        speedInUnitsPerSecond = GetComponent<Rigidbody2D>().velocity.magnitude;

        // If the current mps is greater than or equal to the highest mps speed so far, update the highest speed.
        if (speedInUnitsPerSecond >= highestSpeedInMps)
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

        //[ ] Display the average speed on both

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
    /// TODO
    /// </summary>
    /// <param name="collision">TODO</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
    }

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="_meters"></param>
    /// <param name="_second"></param>
    /// <returns></returns>
    //float metersPerSecond(float _meters, float _second, float _distance, float)
    //{
    //    float _velocity = 0f;

    //    return _velocity;
    //}

}

/// <summary>
/// TODO
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
        // Velocity(Speed) = (Distance(Meters)) / (Time(Seconds))

        // _velocity is meters per second

        float _velocity = 0f;

        // One unity unit is one meter.
        // speedInUnitsPerSecond = GetComponent<Rigidbody2D>().velocity.magnitude;
        // This code above will give us unity units/s, so meters/second


        // Velocity(m/s) = (distance in meters)/(time in seconds)
        //_velocity = (_distance * _meters) / (_time * _seconds);


        _velocity = _meters / _seconds;
        // Speed  = Distance / Time

        return _velocity;
    }


    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="_meters"></param>
    /// <param name="_time"></param>
    /// <returns></returns>
    public float MpsToMph(float _meters, float _second)
    {
        float _mph = 0f;
        float _mps = 0f;

        _mps = MetersPerSecond(_meters, _second);

        _mph = _mps * 2.2369f;

        return _mph;
    }

    /// <summary>
    /// TODO
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
