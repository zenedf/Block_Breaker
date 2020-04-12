using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This handles the paddle.
/// </summary>
public class Paddle : MonoBehaviour
{
    #region Configuration Parameters
    // Screen width of the current window in units.
    [SerializeField] float screenWidthInUnits = 16f;

    // How far left paddle can go.
    [SerializeField] float xMin = 1f;

    // How far right the paddle can go.
    [SerializeField] float xMax = 15f;
    #endregion

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // 'Screen.width' shows the current width of the screen window in pixels.
        // We know that there are currently 16 units. We have 16 Unity units from left to right due to how we set up the camera.
        // (Camera is the size of 6, which is the vertical. That means the total vertical is 12.)
        // (We have a 4:3 aspect ratio. So, given that our camera size is 6, our width is 16. Half of our width is going to be 8.)

        // This variable shows wherever your mouse currently is in relation to the middle of the game window.
        float _mousePositionInUnits = (Input.mousePosition.x / Screen.width) * screenWidthInUnits;

        // This gets the current X and Y positions of the paddle
        Vector2 _paddlePosition = new Vector2(transform.position.x, transform.position.y);

        // This will not let the player exit the left or right bounds of the game window.
        // '_mousePositionInUnits' is the particular value we are manipulating.
        _paddlePosition.x = Mathf.Clamp(_mousePositionInUnits, xMin, xMax);

        // This makes the paddle move
        transform.position = _paddlePosition;
    }
}