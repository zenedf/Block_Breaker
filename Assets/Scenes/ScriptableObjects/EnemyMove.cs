using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is for learning scriptable objects in Unity.
/// </summary>
public class EnemyMove : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    public EnemyData data;
    public SpriteRenderer spriteRenderer;
    #endregion

    #region PRIVATE_VARIABLES
    private float speed;
    Vector3 newPosition;
    #endregion

    #region UNITY_CALLBACKS
    void Update()
    {
        ChangeSpeed();
        gameObject.name = name;
        spriteRenderer.color = data.color;
        newPosition = transform.position;
        newPosition.y = Mathf.Sin(Time.time) * speed;
        transform.position = newPosition;
    }
    #endregion

    #region PROVATE_METHODS
    private void ChangeSpeed()
    {
        speed = Mathf.MoveTowards(speed, data.moveSpeed, Time.deltaTime);
    }
    #endregion
}
