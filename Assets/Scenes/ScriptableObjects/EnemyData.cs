using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy Data")]
public class EnemyData : ScriptableObject
{
    #region PUBLIC_VARIABLE
    public string name;
    public int moveSpeed;
    public Color color;
    public string colorName;
    #endregion
}
