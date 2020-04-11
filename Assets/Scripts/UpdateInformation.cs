using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// TODO
/// </summary>
public class UpdateInformation : MonoBehaviour
{
    [SerializeField] public TMP_Text txtBlockData;
    //[SerializeField] TMP_Text txtMPS_data;
    //[SerializeField] TMP_Text txtHighMPS_data;
    [SerializeField] public TMP_Text txtMPH_data;
    [SerializeField] public TMP_Text txtHighMPH_data;
    [SerializeField] public Ball ballSpeeds;
    [SerializeField] public SceneLoader sceneLoader;
    [SerializeField] public Button btnNextLevel;


    public IList<GameObject> blockList = new List<GameObject>();

    public GameObject[] blockArray;

    public int blocksLeft = 0;

    /// <summary>
    /// TODO
    /// </summary>
    private void Start()
    {
        // This creates an array of objects in the scene with the tag "Block"
        blockList = GameObject.FindGameObjectsWithTag("Block");

        // Are these necessary?
        ballSpeeds.GetComponent<Ball>();
        sceneLoader.GetComponent<SceneLoader>();
        btnNextLevel.GetComponent<Button>();
    }

    /// <summary>
    /// TODO
    /// </summary>
    private void FixedUpdate()
    {
        DisplayInformation();

        // If the player has beaten the current level
        if (blocksLeft == 0)
        {
            // Turns on the 'btnNextLevel'
            btnNextLevel.gameObject.SetActive(true);

            // Turns off 'statsPanel'
            gameObject.SetActive(false);

            // This will pause the game
            sceneLoader.NextLevelButton();
        }
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
    public void DisplayInformation()
    {
        txtBlockData.text = GetRemainingBlocks().ToString();

        txtMPH_data.text = ballSpeeds.GetSpeedInMPH().ToString();
        txtHighMPH_data.text = ballSpeeds.GetHighestSpeedInMPH().ToString();
    }
}

