using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// TODO
/// </summary>
public class UpdateInformation : MonoBehaviour
{
    [SerializeField] TMP_Text txtBlockData;
    //[SerializeField] TMP_Text txtMPS_data;
    //[SerializeField] TMP_Text txtHighMPS_data;
    [SerializeField] TMP_Text txtMPH_data;
    [SerializeField] TMP_Text txtHighMPH_data;

    public IList<GameObject> blockList = new List<GameObject>();

    public GameObject[] blockArray;

    public int blocksLeft = 0;

    public Ball ballSpeeds;

    /// <summary>
    /// TODO
    /// </summary>
    private void Start()
    {
        // This creates an array of objects in the scene with the tag "Block"
        blockList = GameObject.FindGameObjectsWithTag("Block");

        ballSpeeds.GetComponent<Ball>();
    }

    /// <summary>
    /// TODO
    /// </summary>
    private void FixedUpdate()
    {
        DisplayInformation();
    }

    /// <summary>
    /// TODO
    /// </summary>
    /// <returns>TODO</returns>
    public int GetRemainingBlocks()
    {
        blockList = GameObject.FindGameObjectsWithTag("Block");
        blocksLeft = blockList.Count;

        return blocksLeft;
    }

    /// <summary>
    /// TODO
    /// </summary>
    void DisplayInformation()
    {
        txtBlockData.text = GetRemainingBlocks().ToString();

        txtMPH_data.text = ballSpeeds.GetSpeedInMPH().ToString();
        txtHighMPH_data.text = ballSpeeds.GetHighestSpeedInMPH().ToString();
    }
}

